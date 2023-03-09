namespace Shrimply.Repositories
{
    public interface IShrimpLikeRepository
    {
        Task<int> GetTotalLikesForShrimp(Guid shrimpId);
        Task AddShrimpLike(Guid shrimpId, Guid userId);
    }
}
