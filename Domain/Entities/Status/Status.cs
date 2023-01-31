using Domain.Common;

namespace Domain.Entities.Status
{
    public class Status : BaseAuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
