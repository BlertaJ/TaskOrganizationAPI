using System.Text.Json.Serialization;

namespace Application.Common.Management.User.Commands
{
    public class CreateUserDto
    {
        [JsonPropertyName("username")]
        public string Username { get; set; }
        [JsonPropertyName("position")]
        public string Position { get; set; }
    }
}
