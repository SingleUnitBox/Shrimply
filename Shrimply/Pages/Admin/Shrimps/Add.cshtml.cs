using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shrimply.Data;
using Shrimply.Models.Domain;
using Shrimply.Models.ViewModels;

namespace Shrimply.Pages.Admin.Shrimps
{
    public class AddModel : PageModel
    {
        private readonly ShrimplyDbContext _shrimplyDbContext;

        public AddModel(ShrimplyDbContext shrimplyDbContext)
        {
            _shrimplyDbContext = shrimplyDbContext;
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
            await _shrimplyDbContext.AddAsync(shrimp);
            await _shrimplyDbContext.SaveChangesAsync();
            return RedirectToPage("/Admin/Shrimps/List");
        }
    }
}
