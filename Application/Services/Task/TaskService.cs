using Application.Common.Interfaces;
using Application.Common.Interfaces.TaskInterfaces;
using Application.Common.Management.Task.Commands;

namespace Application.Services.Task
{
    public class TaskService : ITaskService
    {
        private readonly IApplicationDbContext _dbContext;
        public TaskService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Domain.Entities.Task.Task> GetProjectStatus(CreateTaskDto taskDto, Domain.Entities.Task.Task task)
        {
            return task;
        }
    }
}
