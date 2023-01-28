namespace Domain.Entities
{
    public class UserTaskMapping : MainEntity
    {
        public int UserId { get; set; }
        public int TaskId { get; set; }
        public User User { get; set; }
        public Task Task { get; set; }
    }
}
