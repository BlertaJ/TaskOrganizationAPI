using Domain.Common;

namespace Domain.Entities.Project
{
    public class ProjectTaskMapping : BaseAuditableEntity
    {
        public int ProjectId { get; set; }
        public int TaskId { get; set; }
        public Domain.Entities.Task.Task Task { get; set; }
        public Project Project { get; set; }
    }
}
