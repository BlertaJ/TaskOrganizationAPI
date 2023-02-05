using Application.Common.Interfaces;
using Application.Common.Management.Project.Queries;
using Application.Common.Management.User.Queries;
using Domain.Entities.Project;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Management.Queries
{
    public record GetProjectsQuery : IRequest<List<SimpleProjectDto>>
    {
        public int ProjectId { get; init; }
    }
    public class GetEmployeWithPaginationQueryHandler : IRequestHandler<GetProjectsQuery, List<SimpleProjectDto>>
    {
        private readonly IApplicationDbContext _context;

        public GetEmployeWithPaginationQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<SimpleProjectDto>> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
        {
            var projects = await _context.Project.Include(x => x.Users)
                .Where(x => x.Id == request.ProjectId)
                .ToListAsync();

            var projectsDto = new List<SimpleProjectDto>();

            foreach (var project in projects)
            {
                var targetList = project.Users
                                       .Select(x => new SimpleUserDto() { UserName = x.UserName })
                                       .ToList();

                projectsDto.Add(new SimpleProjectDto
                {
                    Id = project.Id,
                    Members = targetList
                });
            }
            return projectsDto;
        }
    }
}
