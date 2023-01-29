using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration
{
    public class ProjectTaskMappingConfiguration : IEntityTypeConfiguration<ProjectTaskMapping>
    {
        public void Configure(EntityTypeBuilder<ProjectTaskMapping> builder)
        {
            builder.HasKey(x => new { x.ProjectId, x.TaskId });

            builder.HasOne(x => x.Project)
                .WithMany()
                .HasForeignKey(z => z.ProjectId)
                //.OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasOne(x => x.Task)
                .WithMany()
                .HasForeignKey(z => z.TaskId)
                //.OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
