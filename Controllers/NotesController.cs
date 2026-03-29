using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Dapper;
using NotedApp.Api.Models.Entities;
using NotedApp.Api.Models.DTOs;

[ApiController]
[Route("api/[controller]")]
public class NotesController : ControllerBase
{
    private readonly string _connectionString;

    public NotesController(IConfiguration config)
    {
        _connectionString = config.GetConnectionString("DefaultConnection") 
         ?? throw new InvalidOperationException("DB Connection not found");

        //  Console.WriteLine("DEBUG : ", _connectionString);
    }

    [HttpGet]
    public async Task<IActionResult> GetMyNotes()
    {
        using var db = new SqlConnection(_connectionString);
        // Note the use of note_Id in the SQL string to match your table
        var sql = "SELECT * FROM Notes WHERE UserId = 1 ORDER BY CreatedAt DESC";
        var notes = await db.QueryAsync<Note>(sql);
        return Ok(notes);
    }

    [HttpPost]
    public async Task<IActionResult> CreateNote(NoteCreateDto dto)
    {
        using var db = new SqlConnection(_connectionString);
        var sql = @"INSERT INTO Notes (Title, Content, UserId, CreatedAt, UpdatedAt) 
                    VALUES (@Title, @Content, 1, GETUTCDATE(), GETUTCDATE());
                    SELECT CAST(SCOPE_IDENTITY() as int)";
        
        var newId = await db.QuerySingleAsync<int>(sql, dto);
        return Ok(new { note_Id = newId, message = "Note Created" });
    }
}