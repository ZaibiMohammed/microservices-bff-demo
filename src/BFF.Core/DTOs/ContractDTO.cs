namespace BFF.Core.DTOs
{
    public record ContractDTO
    {
        public string ClientId { get; init; } = string.Empty;
        public List<string> ProductIds { get; init; } = new();
        public DateTime StartDate { get; init; }
        public DateTime EndDate { get; init; }
    }

    public record ContractResponse
    {
        public string ContractId { get; init; } = string.Empty;
        public string ClientId { get; init; } = string.Empty;
        public List<string> ProductIds { get; init; } = new();
        public DateTime StartDate { get; init; }
        public DateTime EndDate { get; init; }
        public string Status { get; init; } = string.Empty;
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; init; }
    }
}