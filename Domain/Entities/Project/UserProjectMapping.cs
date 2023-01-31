using Domain.Common;

namespace Domain.Entities.Project
{
    public class UserProjectMapping : BaseAuditableEntity
    {
        public int UserId { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public Domain.Entities.User.User User { get; set; }
    }
}
