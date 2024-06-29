namespace Financas.Domain.Models
{
    public class Revenue
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Categories { get; set; }
        public required string Description { get; set; }
        public decimal Value { get; set; }
        public DateTime Date { get; set; }
    }
}
