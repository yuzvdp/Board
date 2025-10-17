using Board.Domain.Base;

namespace Board.Domain.Entities
{
    public class Category : EntityBase
    {
        public string? Title { get; set; }
        public List<Advert>? Adverts { get; set; }
    }
}
