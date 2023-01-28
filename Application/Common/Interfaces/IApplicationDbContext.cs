using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<User> User { get; }
        public DbSet<UserTaskMapping> UserTaskMapping { get; }
        public DbSet<Project> Project { get; }
        public DbSet<ProjectTaskMapping> ProjectTaskMapping { get; }
        public DbSet<Domain.Entities.Task> Task { get; }
        public DbSet<Status> Status { get; }
        public DbSet<UserProjectMapping> UserProjectMapping { get; }

        public Task<int> SaveChangesAsync();
        public DbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
        public Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
