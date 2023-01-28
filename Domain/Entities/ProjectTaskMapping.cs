namespace Domain.Entities
{
    public class ProjectTaskMapping : MainEntity
    {
        public int ProjectId { get; set; }
        public int TaskId { get; set; }
        public Task Task { get; set; }
        public Project Project { get; set; }
    }
}
