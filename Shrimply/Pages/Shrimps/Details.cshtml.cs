using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shrimply.Models.Domain;
using Shrimply.Repositories;

namespace Shrimply.Pages.Shrimps
{
    public class DetailsModel : PageModel
    {
        private readonly IShrimpRepository _shrimpRepository;
        private readonly IShrimpLikeRepository _shrimpLikeRepository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public bool Liked { get; set; }
        public int TotalLikes { get; set; }
        public Shrimp Shrimp { get; set; }
        public DetailsModel(IShrimpRepository shrimpRepository,
            IShrimpLikeRepository shrimpLikeRepository,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager
            )
        {
            _shrimpRepository = shrimpRepository;
            _shrimpLikeRepository = shrimpLikeRepository;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<IActionResult> OnGet(string urlHandle)
        {
            Shrimp = await _shrimpRepository.GetAsync(urlHandle);
            if (Shrimp != null)
            {
                if (_signInManager.IsSignedIn(User))
                {
                    var likes = await _shrimpLikeRepository.GetLikesForShrimp(Shrimp.Id);
                    var userId = _userManager.GetUserId(User);

                    Liked = likes.Any(x => x.UserId == Guid.Parse(userId));
                }
       
                TotalLikes = await _shrimpLikeRepository.GetTotalLikesForShrimp(Shrimp.Id);
            }
            return Page();
        }
    }
}
