using Application.Common.Interfaces;
using Domain.Entities.Project;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Management.Queries
{
    public record GetProjectsQuery : IRequest<List<Project>>
    {
        public int EmployeeId { get; init; }
    }
    public class GetEmployeWithPaginationQueryHandler : IRequestHandler<GetProjectsQuery, List<Project>>
    {
        private readonly IApplicationDbContext _context;

        public GetEmployeWithPaginationQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public IApplicationDbContext ApplicationDbContext { get; }

        public async Task<List<Project>> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Project.ToListAsync();
        }
    }
}
