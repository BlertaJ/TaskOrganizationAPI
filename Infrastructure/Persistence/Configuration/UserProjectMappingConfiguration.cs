using Domain.Entities.Project;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration
{
    public class UserProjectMappingConfiguration : IEntityTypeConfiguration<UserProjectMapping>
    {
        public void Configure(EntityTypeBuilder<UserProjectMapping> builder)
        {
            builder.HasKey(x => new { x.ProjectId, x.UserId });

            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(z => z.UserId)
                //.OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasOne(x => x.Project)
                .WithMany()
                .HasForeignKey(z => z.ProjectId)
                //.OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
