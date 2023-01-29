using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration
{
    public class TaskConfiguration : IEntityTypeConfiguration<Domain.Entities.Task.Task>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Task.Task> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
