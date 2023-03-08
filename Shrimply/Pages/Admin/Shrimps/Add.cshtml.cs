using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shrimply.Data;
using Shrimply.Models.Domain;
using Shrimply.Models.ViewModels;
using Shrimply.Repositories;
using System.Text.Json;

namespace Shrimply.Pages.Admin.Shrimps
{
    [Authorize(Roles = "Admin")]
    public class AddModel : PageModel
    {
        private readonly IShrimpRepository _shrimpRepository;

        public AddModel(IShrimpRepository shrimpRepository)
        {
            _shrimpRepository = shrimpRepository;
        }
        [BindProperty]
        public AddShrimp AddShrimpRequest { get; set; }
        [BindProperty]
        public IFormFile FeaturedImage { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {

            var shrimp = new Shrimp
            {
                Name = AddShrimpRequest.Name,
                Description = AddShrimpRequest.Description,
                Color = AddShrimpRequest.Color,
                Family = AddShrimpRequest.Family,
                FeaturedImageUrl = AddShrimpRequest.FeaturedImageUrl,
                UrlHandle = AddShrimpRequest.UrlHandle,
                PublishedDate = AddShrimpRequest.PublishedDate,
                Author = AddShrimpRequest.Author,
                IsVisible = AddShrimpRequest.IsVisible,
                Tags = new List<Tag>(AddShrimpRequest.TagsString.Split(',').Select(x => new Tag() { Name = x.Trim() }))
                
            };
            await _shrimpRepository.AddAsync(shrimp);

            var notification = new Notification
            {
                Message = "Shrimp added successfully.",
                Type = Enums.NotificationType.Success
            };
            TempData["Notification"] = JsonSerializer.Serialize(notification);

            return RedirectToPage("/Admin/Shrimps/List");
        }
    }
}
