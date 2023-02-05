using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Status
{
    public class StatusService
    {
        private readonly IApplicationDbContext _dbContext;
        public StatusService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> GetStatusId(string status)
        {
            var statuses = await _dbContext.Status.ToListAsync();
            var statusId = 0;

            if (statuses.Select(x => x.Name).Contains(status))
                statusId = statuses.Where(x => x.Name == status).FirstOrDefault().Id;

            return statusId;
        }
    }
}
