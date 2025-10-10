namespace Board.Contracts.Adverts
{
    public class AdvertDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? Title { get; set; }
    }
}
