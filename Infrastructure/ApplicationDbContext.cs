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
        public DbSet<UserTask> UserTask => Set<UserTask>();
        public DbSet<Project> Project => Set<Project>();
        public DbSet<ProjectTask> ProjectTask => Set<ProjectTask>();
        public DbSet<Task> Task => Set<Task>();

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
