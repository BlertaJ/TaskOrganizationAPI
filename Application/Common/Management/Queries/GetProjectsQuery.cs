using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
