using Microsoft.AspNetCore.Mvc;
using Shrimply.Models.ViewModels;
using Shrimply.Repositories;

namespace Shrimply.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LikeController : Controller
    {
        private readonly IShrimpLikeRepository _shrimpLikeRepository;

        public LikeController(IShrimpLikeRepository shrimpLikeRepository)
        {
            _shrimpLikeRepository = shrimpLikeRepository;
        }
        [Route("Add")]
        [HttpPost]
        public async Task<IActionResult> AddLike([FromBody] AddLikeRequest addLikeRequest)
        {
            await _shrimpLikeRepository.AddShrimpLike(addLikeRequest.ShrimpId, addLikeRequest.UserId);
            return Ok();
        }

        [HttpGet]
        [Route("{shrimpId:Guid}/totalLikes")]
        public async Task<IActionResult> GetTotalLikes([FromRoute] Guid shrimpId)
        {
            var totalLikes = await _shrimpLikeRepository.GetTotalLikesForShrimp(shrimpId);
            return Ok(totalLikes);
        }
    }
}
