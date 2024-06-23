namespace Financas.Domain.Requests
{
    public record CreateTransactionRequest
    {
        public required string Description { get; set; }
        public decimal Balance { get; set; }
    }
}
