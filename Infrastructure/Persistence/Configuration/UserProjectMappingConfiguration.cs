using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasOne(x => x.Project)
                .WithMany()
                .HasForeignKey(z => z.ProjectId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
