using System.ComponentModel.DataAnnotations;

namespace WebStoreMVC.Models
{
    public class Document
    {
        [Required]
        [MinLength(5, ErrorMessage = "Title must be at least 5 characters long")]
        [MaxLength(30, ErrorMessage = "Title must be less than 50 characters long")]
        public string Title { get; set; }
        [Range(0, 500, ErrorMessage = "Size must be between 0 and 500")]
        public int Size { get; set; }
        public string? Format { get; set; }
    }
}
