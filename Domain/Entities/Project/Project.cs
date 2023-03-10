using Domain.Common;

namespace Domain.Entities.Project
{
    public class Project : BaseAuditableEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Progress { get; set; }
        public int StatusId { get; set; }
        public List<Domain.Entities.User.User> Users { get; set; } = new List<User.User>();
        public List<Domain.Entities.Task.Task> Tasks { get; set; } = new List<Entities.Task.Task>();
    }
}
