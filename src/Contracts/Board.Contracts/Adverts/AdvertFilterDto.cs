namespace Board.Contracts.Adverts
{
    public class AdvertFilterDto : AdvertDto
    {
        public int Page { get; set; }
        public int Take { get; set; }
    }
}
