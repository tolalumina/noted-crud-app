using Microsoft.AspNetCore.Mvc;
using Dapper;
using NotedApp.Api.Models.Entities;
using NotedApp.Api.Models.DTOs;
using NotedApp.Api.Data; // 1. Import your new Data folder


[ApiController]
[Route("api/[controller]")]
public class NotesController : ControllerBase
{
    private readonly NotedDbContext _context;

    // 2. Inject the DataContext instead of IConfiguration
    public NotesController(NotedDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetMyNotes()
    {
        // 3. Use the helper method to get a connection
        using var db = _context.CreateConnection();
        
        var sql = "SELECT * FROM Notes WHERE UserId = 1 ORDER BY CreatedAt DESC";
        var notes = await db.QueryAsync<Note>(sql);
        
        return Ok(notes);
    }

    [HttpPost]
    public async Task<IActionResult> CreateNote(NoteCreateDto dto)
    {
        using var db = _context.CreateConnection();
        
        var sql = @"INSERT INTO Notes (Title, Content, UserId, CreatedAt, UpdatedAt) 
                    VALUES (@Title, @Content, 1, GETUTCDATE(), GETUTCDATE());
                    SELECT CAST(SCOPE_IDENTITY() as int)";
        
        var newId = await db.QuerySingleAsync<int>(sql, dto);
        return Ok(new { note_Id = newId, message = "Note Created" });
    }

    // 4. Added Update (PUT) Example
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateNote(int id, NoteUpdateDto dto)
    {
        using var db = _context.CreateConnection();
        
        var sql = @"UPDATE Notes 
                    SET Title = @Title, Content = @Content, UpdatedAt = GETUTCDATE() 
                    WHERE note_Id = @id AND UserId = 1";
        
        var affected = await db.ExecuteAsync(sql, new { dto.Title, dto.Content, id });
        
        if (affected == 0) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteNoted(int id)
    {
        try
        {
            using var db  = _context.CreateConnection();

            var sql = "DELETE FROM Notes WHERE note_Id = @id AND UserId = 1";
            var rowsAffected = await db.ExecuteAsync(sql, new { id });
            
            if(rowsAffected > 0)
            {
                return Ok(new { status = "Success", message = "Delete success" });
            }
            return NotFound(new { status = "Error", message = "Note not found" });
        }
        catch (Exception)
    {
        // 2. Catch any other unexpected C# errors
        return StatusCode(500, new { status = "Error", message = "An internal server error occurred." });
    }

}

}