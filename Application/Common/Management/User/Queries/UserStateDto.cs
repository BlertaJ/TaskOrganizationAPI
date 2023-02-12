using System.Text.Json.Serialization;

namespace Application.Common.Management.User.Queries
{
    public class UserStateDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("designation")]
        public string Role { get; set; }
    }
}
