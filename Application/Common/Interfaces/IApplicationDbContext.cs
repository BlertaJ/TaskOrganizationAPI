using Domain.Entities.Project;
using Domain.Entities.Status;
using Domain.Entities.Task;
using Domain.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<User> User { get; }
        public DbSet<Project> Project { get; }
        public DbSet<Domain.Entities.Task.Task> Task { get; }
        public DbSet<Status> Status { get; }

        public Task<int> SaveChangesAsync();
        public DbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
        public Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
