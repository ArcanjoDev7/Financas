namespace Financas.Domain.Requests
{
    public record CreateRevenueRequest
    {
        public required string Categories { get; set; }
        public required string Description { get; set; }
        public required string Value { get; set; }
    }
}
