using Shrimply.Models.Domain;

namespace Shrimply.Repositories
{
    public interface IShrimpRepository
    {
        Task AddAsync(Shrimp shrimp);
        Task<IEnumerable<Shrimp>> GetAllAsync();
        Task<Shrimp> GetAsync(Guid id);
        Task<Shrimp> UpdateAsync (Shrimp shrimp);
        Task<bool> DeleteAsync (Guid id);
    }
}
