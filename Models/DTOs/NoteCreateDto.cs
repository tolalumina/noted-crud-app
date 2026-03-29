using System.ComponentModel.DataAnnotations;

namespace NotedApp.Api.Models.DTOs
{
    public class NoteCreateDto
    {
        [Required(ErrorMessage = "Title is required")]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        public string? Content { get; set; }
    }
}