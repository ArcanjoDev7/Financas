namespace Financas.Domain.Requests
{
    public record CreatedAccountRequest
    {
        public required string Name { get; set; }
        public decimal Balance { get; set; }
    }
}
