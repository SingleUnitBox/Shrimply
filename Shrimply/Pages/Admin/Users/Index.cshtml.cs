using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shrimply.Models.ViewModels;
using Shrimply.Repositories;
using System.Text.Json;

namespace Shrimply.Pages.Admin.Users
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<IdentityUser> _userManager;
        [BindProperty]
        public AddUser AddUser { get; set; }
        public List<User> Users { get; set; }
        [BindProperty]
        public Guid SelectedUserId { get; set; }
        public IndexModel(IUserRepository userRepository,
            UserManager<IdentityUser> userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
        }
        public async Task<IActionResult> OnGet()
        
        {
            var notificationJson = (string)TempData["Notification"];
            if (notificationJson != null)
            {
                ViewData["Notification"] = JsonSerializer.Deserialize<Notification>(notificationJson);
            }

            await GetUsers();
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = AddUser.Username,
                    Email = AddUser.Email,
                };
                var roles = new List<string> { "User" };
                if (AddUser.AdminCheckbox)
                {
                    roles.Add("Admin");
                }
                var result = await _userRepository.Add(user, AddUser.Password, roles);

                if (result)
                {
                    var notification = new Notification
                    {
                        Message = "User successfully registered.",
                        Type = Enums.NotificationType.Success
                    };
                    TempData["Notification"] = JsonSerializer.Serialize(notification);
                    return RedirectToPage("/Admin/Users/Index");
                }
                return Page();
            }
            else
            {
                ViewData["Notification"] = new Notification
                {
                    Message = "Something went wrong.",
                    Type = Enums.NotificationType.Error
                };
                await GetUsers();
                return Page();
            }
            
        }
        public async Task<IActionResult> OnPostDelete()
        {
            await _userRepository.Delete(SelectedUserId);

            var notification = new Notification
            {
                Message = "User successfully deleted.",
                Type = Enums.NotificationType.Success
            };
            TempData["Notification"] = JsonSerializer.Serialize(notification);

            return RedirectToPage("/Admin/Users/Index");
        }
        private async Task GetUsers()
        {
            Users = new List<User>();
            var users = (await _userRepository.GetAll()).ToList();
            foreach (var user in users)
            {
                Users.Add(new User
                {
                    Id = Guid.Parse(user.Id),
                    Username = user.UserName,
                    Email = user.Email,
                });
            }
        }
    }
}
