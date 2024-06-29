namespace Financas.Domain.Models
{
    public class Transaction
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public required Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdateTime { get; set; }
    }
}
