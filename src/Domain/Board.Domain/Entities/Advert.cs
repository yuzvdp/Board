using Board.Domain.Base;

namespace Board.Domain.Entities
{
    public class Advert : EntityBase
    {
        public string? Title { get; set; }
        public Guid UserId { get; set; }
        public User? User { get; set; }
        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
