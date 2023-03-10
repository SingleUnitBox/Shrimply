using Microsoft.EntityFrameworkCore;
using Shrimply.Data;
using Shrimply.Models.Domain;

namespace Shrimply.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ShrimplyDbContext _shrimplyDbContext;

        public CommentRepository(ShrimplyDbContext shrimplyDbContext)
        {
            _shrimplyDbContext = shrimplyDbContext;
        }
        public async Task<Comment> AddAsync(Comment comment)
        {
            await _shrimplyDbContext.Comments.AddAsync(comment);
            await _shrimplyDbContext.SaveChangesAsync();
            return comment;
        }

        public async Task<IEnumerable<Comment>> GetAllAsync(Guid shrimpId)
        {
            var comments = await _shrimplyDbContext.Comments.Where(x => x.ShrimpId == shrimpId).ToListAsync();
            return comments;
        }
    }
}
