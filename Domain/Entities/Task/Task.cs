using Domain.Common;

namespace Domain.Entities.Task
{
    public class Task : BaseAuditableEntity
    {
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public Domain.Entities.User.User User { get; set; }
        public string Description { get; set; }
        public double Progress { get; set; }
        public Domain.Entities.Project.Project Project { get; set; }
        public int UserId { get; set; }
        public int StatusId { get; set; }
    }
}
