using System.Text.Json.Serialization;

namespace Application.Common.Management.Project.Queries
{
    public class ProjectDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("description")]

        public string Description { get; set; }
        [JsonPropertyName("progress")]

        public double Progress { get; set; }
        public List<Domain.Entities.User.User> Members { get; set; } = new List<Domain.Entities.User.User>();
        public List<Domain.Entities.Task.Task> Tasks { get; set; } = new List<Domain.Entities.Task.Task>();
        public int StatusId { get; set; }
        [JsonPropertyName("tasks")]
        public int TasksNumber { get; set; }
        [JsonPropertyName("status")]
        public string Status { get; set; }
        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }
    }
}
