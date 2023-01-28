using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class ApplicationDbContextInitializer
    {
        private readonly ApplicationDbContext _context;

        public ApplicationDbContextInitializer(ApplicationDbContext context)
        {
            _context = context;
        }

        public async System.Threading.Tasks.Task InitialiseAsync()
        {
            try
            {
                if (_context.Database.IsSqlServer())
                {
                    await _context.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async System.Threading.Tasks.Task SeedAsync()
        {
            try
            {
                await TrySeedAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async System.Threading.Tasks.Task TrySeedAsync()
        {
            // Default roles
            // Seed, if necessary
            if (!_context.Status.Any())
            {
                _context.Status.AddRange(
                    new Status
                    {
                        Name = "Active",
                    }, new Status
                    {
                        Name = "OnGoing",
                    }, new Status
                    {
                        Name = "Completed",
                    });

                await _context.SaveChangesAsync();
            }
        }
    }
}
