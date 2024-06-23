namespace Financas.Domain.Requests
{
    public record CreateAccountRequest
    {
        public required string Name { get; set; }
        public decimal Balance { get; set; }
    }
}
