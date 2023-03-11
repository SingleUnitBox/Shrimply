using System.ComponentModel.DataAnnotations;

namespace Shrimply.Models.ViewModels
{
    public class AddComment
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
