using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Application.Common.Management.User.Queries
{
    public record GetUsersQuery : IRequest<TaskManagementResponseModel<UserStateDto>>
    {
        public int EmployeeId { get; init; }
        public string UserName { get; set; }
    }
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, TaskManagementResponseModel<UserStateDto>>
    {
        private readonly IApplicationDbContext _context;

        public GetUsersQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TaskManagementResponseModel<UserStateDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var userStateDto = new List<UserStateDto>();
            if (!String.IsNullOrEmpty(request.UserName))
            {
                userStateDto = await _context.User.Where(x => x.UserName == request.UserName)
                    .Select(x => new UserStateDto
                    {
                        Id = x.Id,
                        Name = x.UserName,
                        Role = x.Position
                    }).ToListAsync();

            }
            else if (request.EmployeeId > 0)
            {
                userStateDto = await _context.User.Where(x => x.Id == request.EmployeeId)
                    .Select(x => new UserStateDto
                    {
                        Id = x.Id,
                        Name = x.UserName,
                        Role = x.Position
                    }).ToListAsync();
            }
            userStateDto = await _context.User.Select(x => new UserStateDto
            {
                Id = x.Id,
                Name = x.UserName,
                Role = x.Position
            }).ToListAsync();

            return new TaskManagementResponseModel<UserStateDto>
            {
                Data = userStateDto,
                Message = userStateDto.Count() > 0 ? "success" : "no data",
                StatusCode = userStateDto.Count() > 0 ? HttpStatusCode.OK : HttpStatusCode.BadRequest
            };
        }
    }
}
