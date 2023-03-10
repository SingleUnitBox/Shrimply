namespace Shrimply.Models.ViewModels
{
    public class AddComment
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid ShrimpId { get; set; }
        public Guid UserId { get; set; }
    }
}
