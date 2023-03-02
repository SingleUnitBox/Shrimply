namespace Shrimply.Repositories
{
    public interface IImageRepository
    {
        Task<string> UploadAsync(IFormFile file);
    }
}
