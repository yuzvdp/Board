using Board.Domain.Base;

namespace Board.Domain.Entities
{
    public class User : EntityBase
    {
        public string? Username { get; set; }
        public string? Fio { get; set; }
        public string? Password { get; set; }
        public List<Advert>? Adverts { get; set; } = [];
    }
}
