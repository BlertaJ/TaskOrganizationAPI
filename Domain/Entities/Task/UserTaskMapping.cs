using Domain.Common;

namespace Domain.Entities.Task
{
    public class UserTaskMapping : BaseAuditableEntity
    {
        public int UserId { get; set; }
        public int TaskId { get; set; }
        public Domain.Entities.User.User User { get; set; }
        public Task Task { get; set; }
    }
}
