using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Management.User.Queries
{
    public record GetUsersQuery : IRequest<List<Domain.Entities.User.User>>
    {
        public int EmployeeId { get; init; }
        public string UserName { get; set; }
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
            if (!String.IsNullOrEmpty(request.UserName))
            {
                return await _context.User.Where(x => x.UserName == request.UserName).ToListAsync();
            }
            else if (request.EmployeeId > 0)
            {
                return await _context.User.Where(x => x.Id == request.EmployeeId).ToListAsync();
            }
            return await _context.User.ToListAsync();
        }
    }
}
