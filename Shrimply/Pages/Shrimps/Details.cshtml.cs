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

        public int TotalLikes { get; set; }
        public Shrimp Shrimp { get; set; }
        public DetailsModel(IShrimpRepository shrimpRepository,
            IShrimpLikeRepository shrimpLikeRepository)
        {
            _shrimpRepository = shrimpRepository;
            _shrimpLikeRepository = shrimpLikeRepository;
        }
        public async Task<IActionResult> OnGet(string urlHandle)
        {
            Shrimp = await _shrimpRepository.GetAsync(urlHandle);
            if (Shrimp != null)
            {
                TotalLikes = await _shrimpLikeRepository.GetTotalLikesForShrimp(Shrimp.Id);
            }
            return Page();
        }
    }
}
