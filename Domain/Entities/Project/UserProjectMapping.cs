namespace Domain.Entities.Project
{
    public class UserProjectMapping : MainEntity
    {
        public int UserId { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public Domain.Entities.User.User User { get; set; }
    }
}
