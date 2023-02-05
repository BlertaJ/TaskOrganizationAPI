using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Management.User.Queries
{
    public record GetUsersQuery : IRequest<List<Domain.Entities.User.User>>
    {
        public int EmployeeId { get; init; }
    }
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<Domain.Entities.User.User>>
    {
        private readonly IApplicationDbContext _context;

        public GetUsersQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Domain.Entities.User.User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return await _context.User.ToListAsync();
        }
    }
}
