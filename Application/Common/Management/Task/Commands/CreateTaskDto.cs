using Application.Common.Management.Project.Commands;
using System.Text.Json.Serialization;

namespace Application.Common.Management.Task.Commands
{
    public class CreateTaskDto
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("members")]
        public List<CreateProjectMembersDto> Members { get; set; } = new List<CreateProjectMembersDto>();
        [JsonPropertyName("projectId")]
        public int ProjectId { get; set; }
        public double Progress { get; set; }
        public string Status { get; set; }
    }
}
