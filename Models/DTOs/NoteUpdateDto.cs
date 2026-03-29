using System.ComponentModel.DataAnnotations;

namespace NotedApp.Api.Models.DTOs
{
    public class NoteUpdateDto
    {
        [Required(ErrorMessage = "Title is required for updates")]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        public string? Content { get; set; }
    }
}