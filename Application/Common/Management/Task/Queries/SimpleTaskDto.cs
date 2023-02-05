using Application.Common.Management.User.Queries;

namespace Application.Common.Management.Task.Queries
{
    public class SimpleTaskDto
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public List<SimpleUserDto> Users { get; set; }
        public string Description { get; set; }
        public double Progress { get; set; }
    }
}
