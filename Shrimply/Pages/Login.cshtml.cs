using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shrimply.Models.ViewModels;

namespace Shrimply.Pages
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        [BindProperty]
        public Login LoginViewModel { get; set; }
        public LoginModel(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            var signInResult = await _signInManager.PasswordSignInAsync(
                LoginViewModel.Username, LoginViewModel.Password, false, false);
            if (signInResult.Succeeded)
            {
                return RedirectToPage("Index");      
            }
            else
            {
                ViewData["Notification"] = new Notification
                {
                    Message = "Unable to login.",
                    Type = Enums.NotificationType.Error
                };
                return Page();
            }
            
        }
    }
}
