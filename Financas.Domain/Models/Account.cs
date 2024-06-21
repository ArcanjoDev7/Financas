namespace Financas.Domain.Models
{
    public class Account
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Name { get; set; }
        public decimal Balance { get; set; }
        public required Guid UserId { get; set; }
        public User User { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdateTime { get; set; }
    }
}
