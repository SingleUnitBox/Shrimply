using Shrimply.Models.Domain;

namespace Shrimply.Repositories
{
    public interface ICommentRepository
    {
        Task<Comment> AddAsync(Comment comment);
        Task<IEnumerable<Comment>> GetAllAsync(Guid shrimpId);
    }
}
