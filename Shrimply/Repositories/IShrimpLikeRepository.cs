using Shrimply.Models.Domain;

namespace Shrimply.Repositories
{
    public interface IShrimpLikeRepository
    {
        Task<int> GetTotalLikesForShrimp(Guid shrimpId);
        Task AddShrimpLike(Guid shrimpId, Guid userId);
        Task<IEnumerable<Like>> GetLikesForShrimp(Guid shrimpId);
    }
}
