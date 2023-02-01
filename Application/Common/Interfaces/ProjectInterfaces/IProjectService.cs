using Application.Common.Management.Project.Commands;

namespace Application.Common.Interfaces.ProjectInterfaces
{
    public interface IProjectService
    {
        public Task<Domain.Entities.Project.Project> GetProjectStatus(CreateProjectDto projectDto, Domain.Entities.Project.Project project);
    }
}
