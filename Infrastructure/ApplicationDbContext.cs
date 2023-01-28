using Application.Common.Interfaces;
using Domain.Entities;
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
        public DbSet<UserTaskMapping> UserTaskMapping => Set<UserTaskMapping>();
        public DbSet<Project> Project => Set<Project>();
        public DbSet<ProjectTaskMapping> ProjectTaskMapping => Set<ProjectTaskMapping>();
        public DbSet<Domain.Entities.Task> Task => Set<Domain.Entities.Task>();
        public DbSet<Status> Status => Set<Status>();
        public DbSet<UserProjectMapping> UserProjectMapping => Set<UserProjectMapping>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
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
