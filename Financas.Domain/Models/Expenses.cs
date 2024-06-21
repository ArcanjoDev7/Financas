namespace Financas.Domain.Models
{
    public class Expenses
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Categories { get; set; }
        public required string Description { get; set; }
        public decimal value { get; set; }
        public DateTime Data { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdateTime { get; set; }
    }
}
