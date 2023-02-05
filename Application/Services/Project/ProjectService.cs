using Application.Common.Interfaces;
using Application.Common.Interfaces.ProjectInterfaces;
using Application.Common.Interfaces.StatusInterfaces;
using Application.Common.Management.Project.Commands;
using Domain.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Project
{
    public class ProjectService : IProjectService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IStatusService _statusService;
        public ProjectService(IApplicationDbContext dbContext,
            IStatusService statusService)
        {
            _dbContext = dbContext;
            _statusService = statusService;
        }
        public async Task<Domain.Entities.Project.Project> GetProjectStatus(CreateProjectDto projectDto, Domain.Entities.Project.Project project)
        {
            project.StatusId = await _statusService.GetStatusId(projectDto.Status);
            return project;
        }

        public async Task<Domain.Entities.Project.Project> GetProjectMembers(CreateProjectDto projectDto, Domain.Entities.Project.Project project)
        {
            var userMembersDetails = await _dbContext.User.AsNoTracking().ToListAsync();
            var projectMembers = projectDto.Members.ToList();

            foreach (var projectMember in projectMembers)
            {
                if (userMembersDetails.Select(x => x.UserName).Contains(projectMember.UserName))
                {

                    project.Users
                        .Add(new User
                        {
                            UserName = projectMember.UserName,
                            Id = userMembersDetails.Where(x => x.UserName == projectMember.UserName).FirstOrDefault().Id,
                            Position = userMembersDetails.Where(x => x.UserName == projectMember.UserName).FirstOrDefault().Position
                        });
                }
            }
            return project;
        }
    }
}
