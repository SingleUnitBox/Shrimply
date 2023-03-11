using System.ComponentModel.DataAnnotations;

namespace Shrimply.Models.ViewModels
{
    public class EditShrimp
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public string Family { get; set; }
        [Required]
        public string FeaturedImageUrl { get; set; }
        [Required]
        public string UrlHandle { get; set; }
        [Required]
        public DateTime PublishedDate { get; set; }
        [Required]
        public string Author { get; set; }
        public bool IsVisible { get; set; }
        [Required]
        public string TagsString { get; set; }
    }
}
