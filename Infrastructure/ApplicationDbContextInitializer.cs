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

        public async Task InitialiseAsync()
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
        public async Task SeedAsync()
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

        public async Task TrySeedAsync()
        {
            // Default roles
            // Seed, if necessary
            //if (!_context.EmployeeRole.Any())
            //{
            //    _context.EmployeeRole.AddRange(
            //        new EmployeeRole
            //        {
            //            Name = "Employee",
            //        }, new EmployeeRole
            //        {
            //            Name = "Manager",
            //        }, new EmployeeRole
            //        {
            //            Name = "DepartmentLead",
            //        });

            //    await _context.SaveChangesAsync();
            //}
        }
    }
}
