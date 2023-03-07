using Shrimply.Models.Domain;

namespace Shrimply.Repositories
{
    public interface ITagRepository
    {
        Task<IEnumerable<Tag>> GetAllAsync();
    }
}
