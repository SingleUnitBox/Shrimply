using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shrimply.Models.ViewModels;

namespace Shrimply.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;

        public RegisterModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        [BindProperty]
        public Register RegisterViewModel { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            var user = new IdentityUser
            {
                UserName = RegisterViewModel.Username,
                Email = RegisterViewModel.Email,
            };
            var identityResult = await _userManager.CreateAsync(user, RegisterViewModel.Password);

            if (identityResult.Succeeded)
            {
                var addRolesResult = await _userManager.AddToRoleAsync(user, "User");
                if (addRolesResult.Succeeded)
                {
                    ViewData["Notification"] = new Notification
                    {
                        Message = "User has been successfully registered.",
                        Type = Enums.NotificationType.Success
                    };
                }
                return Page();
            }
            ViewData["Notification"] = new Notification
            {
                Message = "Something went wrong.",
                Type = Enums.NotificationType.Error
            };
            return Page();
        }
    }
}
