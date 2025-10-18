using Board.Contracts.Attributes;

namespace Board.Contracts.Adverts
{
    public class CreateAdvertDto
    {
        [BadAdvertTitlesValidationAttribute]
        public string? Title { get; set; }
        public Guid UserID { get; set; }
        public string? Username { get; set; }
        public Guid CategoryId { get; set; }
        public string? CategoryTitle { get; set; }
    }
}
