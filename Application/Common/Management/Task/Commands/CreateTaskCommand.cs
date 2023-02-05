using Application.Common.Interfaces;
using Application.Common.Interfaces.ProjectInterfaces;
using MediatR;

namespace Application.Common.Management.Task.Commands
{
    public record CreateTaskCommand(CreateTaskDto Task) : IRequest<Domain.Entities.Task.Task>;

    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Domain.Entities.Task.Task>
    {
        private readonly IApplicationDbContext _context;
        private readonly IProjectService _projectService;
        public CreateTaskCommandHandler(IApplicationDbContext context,
            IProjectService projectService)
        {
            _context = context;
            _projectService = projectService;

        }
        public async Task<Domain.Entities.Task.Task> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = new Domain.Entities.Task.Task
            {
                Title = request.Task.Title,
                Description = request.Task.Description,
                Progress = request.Task.Progress
            };

            var insertedProject = await _context.Task.AddAsync(task);

            await _context.SaveChangesAsync();
            return insertedProject.Entity;
        }
    }
}
