using Application.Common.Interfaces;
using Application.Common.Interfaces.TaskInterfaces;
using MediatR;

namespace Application.Common.Management.Task.Commands
{
    public record CreateTaskCommand(CreateTaskDto Task) : IRequest<int>;

    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly ITaskService _taskService;
        public CreateTaskCommandHandler(IApplicationDbContext context,
            ITaskService taskService)
        {
            _context = context;
            _taskService = taskService;
        }
        public async Task<int> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = new Domain.Entities.Task.Task
            {
                Title = request.Task.Title,
                Description = request.Task.Description,
                Progress = request.Task.Progress,
                ProjectId = request.Task.ProjectId
            };

            task = await _taskService.GetTaskStatus(request.Task, task);

            var insertedProject = await _context.Task.AddAsync(task);

            await _context.SaveChangesAsync();

            task = await _taskService.GetTaskMembers(request.Task, task);

            await _context.SaveChangesAsync();

            return insertedProject.Entity.Id;
        }
    }
}
