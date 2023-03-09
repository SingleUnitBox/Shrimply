using Microsoft.EntityFrameworkCore;
using Shrimply.Data;
using Shrimply.Models.Domain;

namespace Shrimply.Repositories
{
    public class ShrimpLikeRepository : IShrimpLikeRepository
    {
        private readonly ShrimplyDbContext _shrimplyDbContext;
        public ShrimpLikeRepository(ShrimplyDbContext shrimplyDbContext)
        {
            _shrimplyDbContext = shrimplyDbContext;
        }

        public async Task AddShrimpLike(Guid shrimpId, Guid userId)
        {
            var like = new Like
            {
                ShrimpId = shrimpId,
                UserId = userId
            };
            await _shrimplyDbContext.Like.AddAsync(like);
            await _shrimplyDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Like>> GetLikesForShrimp(Guid shrimpId)
        {
            var likes = await _shrimplyDbContext.Like.Where(x => x.ShrimpId == shrimpId)
                .ToListAsync();
            return likes;
        }

        public async Task<int> GetTotalLikesForShrimp(Guid shrimpId)
        {
            return await _shrimplyDbContext.Like.CountAsync(x => x.ShrimpId == shrimpId);
        }
    }
}
