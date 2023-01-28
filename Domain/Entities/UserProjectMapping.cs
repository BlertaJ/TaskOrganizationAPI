namespace Domain.Entities
{
    public class UserProjectMapping : MainEntity
    {
        public int UserId { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public User User { get; set; }
    }
}
