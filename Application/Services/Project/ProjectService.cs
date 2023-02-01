using Application.Common.Interfaces;
using Application.Common.Interfaces.ProjectInterfaces;
using Application.Common.Management.Project.Commands;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Project
{
    public class ProjectService : IProjectService
    {
        private readonly IApplicationDbContext _dbContext;
        public ProjectService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Domain.Entities.Project.Project> GetProjectStatus(CreateProjectDto projectDto, Domain.Entities.Project.Project project)
        {
            var statuses = await _dbContext.Status.ToListAsync();
            if (statuses.Select(x => x.Name).Contains(projectDto.Status))
                project.StatusId = statuses.Where(x => x.Name == projectDto.Status).FirstOrDefault().Id;

            return project;
        }
    }
}
