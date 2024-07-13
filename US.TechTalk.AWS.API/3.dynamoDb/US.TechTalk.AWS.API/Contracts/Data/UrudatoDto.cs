using System.Text.Json.Serialization;

namespace US.TechTalk.AWS.API.Contracts.Data
{
    public class UrudatoDto
    {
        [JsonPropertyName("pk")]
        public string Pk => Id.ToString();

        [JsonPropertyName("sk")]
        public string Sk => Id.ToString();

        public Guid Id { get; init; } = default!;

        public string Name { get; init; } = default!;

        public string Email { get; init; } = default!;

        public DateTime DateOfBirth { get; init; }

        public DateTime UpdatedAt { get; set; }
    }
}
