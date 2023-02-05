using Application.Common.Management.Task.Commands;

namespace Application.Common.Interfaces.TaskInterfaces
{
    public interface ITaskService
    {
        public Task<Domain.Entities.Task.Task> GetTaskStatus(CreateTaskDto taskDto, Domain.Entities.Task.Task task);
        public Task<Domain.Entities.Task.Task> GetTaskMembers(CreateTaskDto taskDto, Domain.Entities.Task.Task task);

    }
}
