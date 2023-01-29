using Application.Common.Interfaces;
using Domain.Entities.Project;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Management.Queries
{
    public record GetProjectsQuery : IRequest<List<Domain.Entities.Project.Project>>
    {
        public int EmployeeId { get; init; }
    }
    public class GetEmployeWithPaginationQueryHandler : IRequestHandler<GetProjectsQuery, List<Domain.Entities.Project.Project>>
    {
        private readonly IApplicationDbContext _context;

        public GetEmployeWithPaginationQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Domain.Entities.Project.Project>> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Project.ToListAsync();
        }
    }
}
