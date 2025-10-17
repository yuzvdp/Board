namespace Board.Contracts.Categories
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? Title { get; set; }
    }
}
