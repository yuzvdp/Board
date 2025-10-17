namespace Board.Contracts.Users
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? Username { get; set; }
        public string? Fio { get; set; }
        public string? Password { get; set; }
    }
}
