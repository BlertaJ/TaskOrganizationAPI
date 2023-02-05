using Application.Common.Interfaces;
using Application.Common.Interfaces.ProjectInterfaces;
using Domain.Entities.User;
using MediatR;

namespace Application.Common.Management.Project.Commands
{
    public record CreateProjectCommand(CreateProjectDto Project) : IRequest<int>;

    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IProjectService _projectService;
        public CreateProjectCommandHandler(IApplicationDbContext context,
            IProjectService projectService)
        {
            _context = context;
            _projectService = projectService;
        }
        public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = new Domain.Entities.Project.Project
            {
                Title = request.Project.Title,
                Description = request.Project.Description,
                Progress = request.Project.Progress
            };

            project = await _projectService.GetProjectStatus(request.Project, project);

            var insertedProject = await _context.Project.AddAsync(project);

            await _context.SaveChangesAsync();

            project = await _projectService.GetProjectMembers(request.Project, project);

            await _context.SaveChangesAsync();

            return insertedProject.Entity.Id;
        }
    }
}
