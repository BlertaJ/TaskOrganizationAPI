using Application.Common.Management.User.Queries;

namespace Application.Common.Management.Project.Queries
{
    public class SimpleProjectDto
    {
        public int Id { get; set; }
        public List<SimpleUserDto> Members { get; set; }
    }
}
