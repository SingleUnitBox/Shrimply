using System.ComponentModel.DataAnnotations;

namespace Shrimply.Models.ViewModels
{
    public class Login
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [MinLength(4)]
        public string Password { get; set; }
    }
}
