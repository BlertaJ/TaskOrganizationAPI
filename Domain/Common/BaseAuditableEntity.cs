using Domain.Entities;

namespace Domain.Common
{
    public class BaseAuditableEntity : MainEntity
    {
        public DateTime CreatedOnDate { get; set; } = DateTime.UtcNow;

        public string? CreatedBy { get; set; } = "blerta";

        public DateTime? UpdatedOnDate { get; set; } = DateTime.UtcNow;

        public string? UpdatedBy { get; set; } = "blerta";
    }
}
