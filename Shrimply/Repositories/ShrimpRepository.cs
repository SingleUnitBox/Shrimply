using Microsoft.EntityFrameworkCore;
using Shrimply.Data;
using Shrimply.Models.Domain;

namespace Shrimply.Repositories
{
    public class ShrimpRepository : IShrimpRepository
    {
        private readonly ShrimplyDbContext _shrimplyDbContext;

        public ShrimpRepository(ShrimplyDbContext shrimplyDbContext)
        {
            _shrimplyDbContext = shrimplyDbContext;
        }
        public async Task AddAsync(Shrimp shrimp)
        {
            await _shrimplyDbContext.Shrimps.AddAsync(shrimp);
            await _shrimplyDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Shrimp>> GetAllAsync()
        {
            var shrimps = await _shrimplyDbContext.Shrimps.ToListAsync();
            return shrimps;
        }
    }
}
