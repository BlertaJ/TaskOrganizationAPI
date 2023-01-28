namespace Domain.Entities
{
    public class Task : MainEntity
    {
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public User User { get; set; }
        public string Description { get; set; }
        public double Progress { get; set; }
        public Project Project { get; set; }
        public int UserId { get; set; }
        public int StatusId { get; set; }
    }
}
