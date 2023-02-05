using Domain.Common;
using Domain.Entities.Project;

namespace Domain.Entities.User
{
    public class User : BaseAuditableEntity
    {
        public string UserName { get; set; }
        public string Position { get; set; }
        public List<Domain.Entities.Project.Project> Projects { get; set; } = new List<Domain.Entities.Project.Project>();
        public List<Domain.Entities.Task.Task> Tasks { get; set; } = new List<Domain.Entities.Task.Task>();

    }
}
