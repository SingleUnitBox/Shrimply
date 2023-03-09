namespace Shrimply.Models.Domain
{
    public class Like
    {
        public Guid Id { get; set; }
        public Guid ShrimpId { get; set; }
        public Guid UserId { get; set; }
    }
}
