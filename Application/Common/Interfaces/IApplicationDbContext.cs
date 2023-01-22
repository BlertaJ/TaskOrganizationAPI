using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<User> User { get; }
        public DbSet<UserTask> UserTask { get; }
        public DbSet<Project> Project { get; }
        public DbSet<ProjectTask> ProjectTask { get; }
        public DbSet<Task> Task { get; }

        public Task<int> SaveChangesAsync();
        public DbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
        public Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
