namespace Financas.Domain.Requests
{
    public record CreateExpensesRequest
    {
        public required string Categories { get; set; }
        public required string Description { get; set; }
        public required string value { get; set; }
    }
}
