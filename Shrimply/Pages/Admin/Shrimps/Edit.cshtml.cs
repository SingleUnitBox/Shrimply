using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shrimply.Data;
using Shrimply.Models.Domain;
using Shrimply.Models.ViewModels;
using Shrimply.Repositories;

namespace Shrimply.Pages.Admin.Shrimps
{
    public class EditModel : PageModel
    {
        private readonly IShrimpRepository _shrimpRepository;

        public EditModel(IShrimpRepository shrimpRepository)
        {
            _shrimpRepository = shrimpRepository;
        }
        [BindProperty]
        public EditShrimp Shrimp { get; set; }
        public async Task OnGet(Guid id)
        {
            var shrimpDomainModel = await _shrimpRepository.GetAsync(id);
            if (shrimpDomainModel != null)
            {
                Shrimp = new EditShrimp
                {
                    Id = shrimpDomainModel.Id,
                    Name = shrimpDomainModel.Name,
                    Description = shrimpDomainModel.Description,
                    Color = shrimpDomainModel.Color,
                    Family = shrimpDomainModel.Family,
                    FeaturedImageUrl = shrimpDomainModel.FeaturedImageUrl,
                    UrlHandle = shrimpDomainModel.UrlHandle,
                    PublishedDate = shrimpDomainModel.PublishedDate,
                    Author = shrimpDomainModel.Author,
                    IsVisible = shrimpDomainModel.IsVisible,
                };
            }
        }
        public async Task<IActionResult> OnPostEdit()
        {
            var shrimpDomainModel = new Shrimp
            {
                Id = Shrimp.Id,
                Name = Shrimp.Name,
                Description = Shrimp.Description,
                Color = Shrimp.Color,
                Family = Shrimp.Family,
                FeaturedImageUrl = Shrimp.FeaturedImageUrl,
                UrlHandle = Shrimp.UrlHandle,
                PublishedDate = Shrimp.PublishedDate,
                Author = Shrimp.Author,
                IsVisible = Shrimp.IsVisible,
            };
            await _shrimpRepository.UpdateAsync(shrimpDomainModel);
            ViewData["Notification"] = new Notification
            {
                Message = "Shrimp successfully edited.",
                Type = Enums.NotificationType.Success
            };

            return Page();
        }
        public async Task<IActionResult> OnPostDelete()
        {
            var deleted = await _shrimpRepository.DeleteAsync(Shrimp.Id);
            if (deleted)
            {
                return RedirectToPage("/Admin/Shrimps/List");
            }
            return Page();

        }
    }
}
