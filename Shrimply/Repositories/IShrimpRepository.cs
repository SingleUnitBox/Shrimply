using Shrimply.Models.Domain;

namespace Shrimply.Repositories
{
    public interface IShrimpRepository
    {
        Task AddAsync(Shrimp shrimp);
        Task<IEnumerable<Shrimp>> GetAllAsync();
        Task<IEnumerable<Shrimp>> GetAllAsync(string tagName);
        Task<Shrimp> GetAsync(Guid id);
        Task<Shrimp> GetAsync(string urlHandle);
        Task<Shrimp> UpdateAsync (Shrimp shrimp);
        Task<bool> DeleteAsync (Guid id);
    }
}
