using Application.Common.Interfaces;
using Application.Common.Management.Task.Queries;
using Application.Common.Management.User.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Management.Task
{
    public record GetProjectTasksQuery : IRequest<List<SimpleTaskDto>>
    {
        public int TaskId { get; init; }
    }
    public class GetEmployeWithPaginationQueryHandler : IRequestHandler<GetProjectTasksQuery, List<SimpleTaskDto>>
    {
        private readonly IApplicationDbContext _context;

        public GetEmployeWithPaginationQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<SimpleTaskDto>> Handle(GetProjectTasksQuery request, CancellationToken cancellationToken)
        {

            var projectsTask = from task in _context.Task.Include(x => x.Users)
                               join project in _context.Project on task.ProjectId equals project.Id
                               select task;


            var projectsDto = new List<SimpleTaskDto>();

            foreach (var projectTask in projectsTask)
            {
                var targetList = projectTask.Users
                                       .Select(x => new SimpleUserDto() { UserName = x.UserName })
                                       .ToList();

                projectsDto.Add(new SimpleTaskDto
                {
                    Id = projectTask.Id,
                    ProjectId = projectTask.ProjectId,
                    Users = targetList,
                    Title = projectTask.Title,
                    Description = projectTask.Description,
                    Progress = projectTask.Progress
                });
            }
            return projectsDto;
        }
    }
}
