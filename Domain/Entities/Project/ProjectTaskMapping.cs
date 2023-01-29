namespace Domain.Entities.Project
{
    public class ProjectTaskMapping : MainEntity
    {
        public int ProjectId { get; set; }
        public int TaskId { get; set; }
        public Domain.Entities.Task.Task Task { get; set; }
        public Project Project { get; set; }
    }
}
