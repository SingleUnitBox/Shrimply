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
    public class EditModel : PageModel
    {
        private readonly IShrimpRepository _shrimpRepository;

        public EditModel(IShrimpRepository shrimpRepository)
        {
            _shrimpRepository = shrimpRepository;
        }
        [BindProperty]
        public EditShrimp Shrimp { get; set; }
        public IFormFile FeaturedImage { get; set; }
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
                    TagsString = string.Join(", ", shrimpDomainModel.Tags.Select(x => x.Name))
                };
            }
        }
        public async Task<IActionResult> OnPostEdit()
        {
            try
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
                    Tags = new List<Tag>(Shrimp.TagsString.Split(',').Select(x => new Tag() { Name = x.Trim() }))
                };
                await _shrimpRepository.UpdateAsync(shrimpDomainModel);
                ViewData["Notification"] = new Notification
                {
                    Message = "Shrimp successfully edited.",
                    Type = Enums.NotificationType.Success
                };
            }
            catch (Exception ex)
            {
                ViewData["Notification"] = new Notification
                {
                    Message = "Something went wrong.",
                    Type = Enums.NotificationType.Error
                };
            }
            return Page();

        }
        public async Task<IActionResult> OnPostDelete()
        {
            var deleted = await _shrimpRepository.DeleteAsync(Shrimp.Id);
            if (deleted)
            {
                var notification = new Notification
                {
                    Message = "Shrimp was successfully deleted.",
                    Type = Enums.NotificationType.Success
                };
                TempData["Notification"] = JsonSerializer.Serialize(notification);
                return RedirectToPage("/Admin/Shrimps/List");
            }
            return Page();

        }
    }
}
