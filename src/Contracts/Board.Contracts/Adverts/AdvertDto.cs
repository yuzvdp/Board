using Board.Contracts.Categories;
using Board.Contracts.Users;

namespace Board.Contracts.Adverts
{
    public class AdvertDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? Title { get; set; }
        public Guid UserId { get; set; }
        public UserDto? UserDto { get; set; }
        public Guid CategoryId { get; set; }
        public CategoryDto? CategoryDto { get; set; }
    }
}
