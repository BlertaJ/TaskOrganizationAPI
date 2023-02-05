using Application.Common.Interfaces;
using Application.Common.Interfaces.StatusInterfaces;
using Application.Common.Interfaces.TaskInterfaces;
using Application.Common.Management.Task.Commands;
using Domain.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Task
{
    public class TaskService : ITaskService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IStatusService _statusService;
        public TaskService(IApplicationDbContext dbContext,
            IStatusService statusService)
        {
            _dbContext = dbContext;
            _statusService = statusService;
        }
        public async Task<Domain.Entities.Task.Task> GetTaskStatus(CreateTaskDto taskDto, Domain.Entities.Task.Task task)
        {
            task.StatusId = await _statusService.GetStatusId(taskDto.Status);
            return task;
        }
        public async Task<Domain.Entities.Task.Task> GetTaskMembers(CreateTaskDto taskDto, Domain.Entities.Task.Task task)
        {
            var userMembersDetails = await _dbContext.User.AsNoTracking().ToListAsync();
            var projectMembers = taskDto.Members.ToList();

            foreach (var projectMember in projectMembers)
            {
                if (userMembersDetails.Select(x => x.UserName).Contains(projectMember.UserName))
                {

                    task.Users
                        .Add(new User
                        {
                            UserName = projectMember.UserName,
                            Id = userMembersDetails.Where(x => x.UserName == projectMember.UserName).FirstOrDefault().Id,
                            Position = userMembersDetails.Where(x => x.UserName == projectMember.UserName).FirstOrDefault().Position
                        });
                }
            }
            return task;
        }
    }
}
