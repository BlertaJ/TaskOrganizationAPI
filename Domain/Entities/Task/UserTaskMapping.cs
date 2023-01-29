namespace Domain.Entities.Task
{
    public class UserTaskMapping : MainEntity
    {
        public int UserId { get; set; }
        public int TaskId { get; set; }
        public Domain.Entities.User.User User { get; set; }
        public Task Task { get; set; }
    }
}
