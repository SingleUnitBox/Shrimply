using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shrimply.Data;
using Shrimply.Models.Domain;
using Shrimply.Models.ViewModels;
using Shrimply.Repositories;

namespace Shrimply.Pages.Admin.Shrimps
{
    public class AddModel : PageModel
    {
        private readonly IShrimpRepository _shrimpRepository;

        public AddModel(IShrimpRepository shrimpRepository)
        {
            _shrimpRepository = shrimpRepository;
        }
        [BindProperty]
        public AddShrimp AddShrimpRequest { get; set; }
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
            };
            await _shrimpRepository.AddAsync(shrimp);
            return RedirectToPage("/Admin/Shrimps/List");
        }
    }
}