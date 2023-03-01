using Shrimply.Models.Domain;

namespace Shrimply.Repositories
{
    public interface IShrimpRepository
    {
        public Task AddAsync(Shrimp shrimp);
        public Task<IEnumerable<Shrimp>> GetAllAsync();
    }
}
