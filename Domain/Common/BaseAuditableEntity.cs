using Domain.Entities;

namespace Domain.Common
{
    public class BaseAuditableEntity : MainEntity
    {
        public DateTime CreatedOnDate { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? UpdatedOnDate { get; set; }

        public string? UpdatedBy { get; set; }
    }
}
