using Application.Common.Interfaces;
using MediatR;

namespace Application.Common.Management.Project.Commands
{
    public record CreateProjectCommand : IRequest<Domain.Entities.Project.Project>
    {
        public Domain.Entities.Project.Project Project { get; set; }
    }

    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, Domain.Entities.Project.Project>
    {
        private readonly IApplicationDbContext _context;
        public async Task<Domain.Entities.Project.Project> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            await _context.Project.AddAsync(request.Project);
            return request.Project;
        }
    }
}
