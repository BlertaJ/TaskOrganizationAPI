using Domain.Common;

namespace Domain.Entities.User
{
    public class User : BaseAuditableEntity
    {
        public string UserName { get; set; }
        public string Position { get; set; }
    }
}
