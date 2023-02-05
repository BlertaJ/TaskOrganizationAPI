using Application.Common.Interfaces;
using Application.Common.Interfaces.StatusInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Status
{
    public class StatusService : IStatusService
    {
        private readonly IApplicationDbContext _dbContext;
        public StatusService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> GetStatusId(string status)
        {
            var statuses = await _dbContext.Status.ToListAsync();

            return statuses.Select(x => x.Name).Contains(status) ?
                statuses.Where(x => x.Name == status).FirstOrDefault().Id : 0;
        }
    }
}
