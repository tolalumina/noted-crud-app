using System.ComponentModel.DataAnnotations;

namespace NotedApp.Api.Models.DTOs
{
    public class NoteCreateDto
    {
        [Required(ErrorMessage = "Title is mandatory")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
        public string Title { get; set; } = string.Empty;

        // Content is optional (Nullable)
        public string? Content { get; set; }
    }
}