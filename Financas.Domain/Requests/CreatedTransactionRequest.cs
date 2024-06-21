namespace Financas.Domain.Requests
{
    public record CreatedTransactionRequest
    {
        public required string Description { get; set; }
        public decimal Balance { get; set; }
    }
}
