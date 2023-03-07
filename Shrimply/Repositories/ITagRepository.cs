using Shrimply.Models.Domain;

namespace Shrimply.Repositories
{
    public interface ITagRepository
    {
        Task<Tag> GetAsync(string tagName);
        Task<IEnumerable<Tag>> GetAllAsync();
    }
}
