using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shrimply.Models.Domain;
using Shrimply.Models.ViewModels;
using Shrimply.Repositories;
using System.Text.Json;

namespace Shrimply.Pages.Shrimps
{
    public class DetailsModel : PageModel
    {
        private readonly IShrimpRepository _shrimpRepository;
        private readonly IShrimpLikeRepository _shrimpLikeRepository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ICommentRepository _commentRepository;
        public List<ShrimpComment> Comments { get; set; }
        public bool Liked { get; set; }
        public int TotalLikes { get; set; }
        public Shrimp Shrimp { get; set; }
        [BindProperty]
        public Guid ShrimpIdRequest { get; set; }
        [BindProperty]
        public AddComment AddCommentRequest { get; set; }
        public DetailsModel(IShrimpRepository shrimpRepository,
            IShrimpLikeRepository shrimpLikeRepository,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ICommentRepository commentRepository
            )
        {
            _shrimpRepository = shrimpRepository;
            _shrimpLikeRepository = shrimpLikeRepository;
            _userManager = userManager;
            _signInManager = signInManager;
            _commentRepository = commentRepository;
        }
        public async Task<IActionResult> OnGet(string urlHandle)
        {
            var notificationJson = (string)TempData["Notification"];
            if (notificationJson != null)
            {
                ViewData["Notification"] = JsonSerializer.Deserialize<Notification>(notificationJson);
            }

            await GetShrimp(urlHandle);
            return Page();
        }
        public async Task<IActionResult> OnPost(string urlHandle)
        {
            if (ModelState.IsValid)
            {
                if (_signInManager.IsSignedIn(User))
                {
                    var userId = _userManager.GetUserId(User);
                    var comment = new Comment
                    {
                        Title = AddCommentRequest.Title,
                        Content = AddCommentRequest.Content,
                        ShrimpId = ShrimpIdRequest,
                        UserId = Guid.Parse(userId),
                        DatePublished = DateTime.UtcNow,

                    };
                    await _commentRepository.AddAsync(comment);

                    var notification = new Notification
                    {
                        Message = "Comment added successfully.",
                        Type = Enums.NotificationType.Success
                    };
                    TempData["Notification"] = JsonSerializer.Serialize(notification);

                    return RedirectToPage("/Shrimps/Details", new { urlHandle = urlHandle });

                }
                ViewData["Notification"] = new Notification
                {
                    Message = "Cannot add comment",
                    Type = Enums.NotificationType.Error
                };
                return Page();
            }
            await GetShrimp(urlHandle);
            return Page();

        }
        private async Task GetComments()
        {
            var shrimpComments = await _commentRepository.GetAllAsync(Shrimp.Id);
            var shrimpCommentsViewModel = new List<ShrimpComment>();
            foreach (var comment in shrimpComments)
            {
                shrimpCommentsViewModel.Add(new ShrimpComment
                {
                    DatePublished = comment.DatePublished,
                    Title = comment.Title,
                    Content = comment.Content,
                    Username = (await _userManager.FindByIdAsync(comment.UserId.ToString())).UserName
                });
                Comments = shrimpCommentsViewModel;
            }
        }
        private async Task GetShrimp(string urlHandle)
        {
            Shrimp = await _shrimpRepository.GetAsync(urlHandle);
            if (Shrimp != null)
            {
                ShrimpIdRequest = Shrimp.Id;
                if (_signInManager.IsSignedIn(User))
                {
                    var likes = await _shrimpLikeRepository.GetLikesForShrimp(Shrimp.Id);
                    var userId = _userManager.GetUserId(User);

                    Liked = likes.Any(x => x.UserId == Guid.Parse(userId));
                    await GetComments();
                }

                TotalLikes = await _shrimpLikeRepository.GetTotalLikesForShrimp(Shrimp.Id);
            }
        }
    }
}
