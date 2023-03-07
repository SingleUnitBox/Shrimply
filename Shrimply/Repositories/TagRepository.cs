using Microsoft.EntityFrameworkCore;
using Shrimply.Data;
using Shrimply.Models.Domain;

namespace Shrimply.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly ShrimplyDbContext _shrimplyDbContext;

        public TagRepository(ShrimplyDbContext shrimplyDbContext)
        {
            _shrimplyDbContext = shrimplyDbContext;
        }
        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            var tags = await _shrimplyDbContext.Tags.ToListAsync();
            return tags.DistinctBy(x => x.Name.ToLower());
        }

        public async Task<Tag> GetAsync(string tagName)
        {
            var tag = await _shrimplyDbContext.Tags.FirstOrDefaultAsync(x => x.Name == tagName);
            return tag;
        }
    }
}
