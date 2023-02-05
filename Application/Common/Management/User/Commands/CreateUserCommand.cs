using Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Management.User.Commands
{
    public record CreateUserCommand(CreateUserDto User) : IRequest<Domain.Entities.User.User>;

    public class CreateProjectCommandHandler : IRequestHandler<CreateUserCommand, Domain.Entities.User.User>
    {
        private readonly IApplicationDbContext _context;
        public CreateProjectCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Domain.Entities.User.User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var insertedUser = await _context.User.AddAsync(new Domain.Entities.User.User
            {
                UserName = request.User.Username,
                Position = request.User.Position
            });

            await _context.SaveChangesAsync();
            return insertedUser.Entity;
        }
    }
}
