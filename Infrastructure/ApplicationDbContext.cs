using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Entities.Project;
using Domain.Entities.Status;
using Domain.Entities.Task;
using Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace Infrastructure
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {

        public ApplicationDbContext(
           DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<User> User => Set<User>();
        public DbSet<Project> Project => Set<Project>();
        public DbSet<Domain.Entities.Task.Task> Task => Set<Domain.Entities.Task.Task>();
        public DbSet<Status> Status => Set<Status>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors();
        }
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
        public int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
