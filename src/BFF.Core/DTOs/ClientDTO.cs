namespace BFF.Core.DTOs
{
    public record ClientDTO
    {
        public string? Name { get; init; }
        public string? Email { get; init; }
        public string? Phone { get; init; }
    }

    public record ClientResponse
    {
        public string ClientId { get; init; } = string.Empty;
        public string Name { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
        public string Phone { get; init; } = string.Empty;
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; init; }
    }
}