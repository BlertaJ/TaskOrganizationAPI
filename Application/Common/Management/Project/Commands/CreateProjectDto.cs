using System.Text.Json.Serialization;

namespace Application.Common.Management.Project.Commands
{
    public class CreateProjectDto
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("description")]

        public string Description { get; set; }
        [JsonPropertyName("progress")]

        public double Progress { get; set; }
        [JsonPropertyName("members")]

        public List<CreateProjectMembersDto> Members { get; set; } = new List<CreateProjectMembersDto>();
        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
}
