namespace Domain.Entities
{
    public class Project : MainEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Progress { get; set; }
        public List<User> Members { get; set; } = new List<User>();
        public DateTime CreatedDate { get; set; }
        public List<Task> Tasks { get; set; } = new List<Task>();
        public int StatusId { get; set; }
    }
}
