namespace Application.Common.Interfaces.StatusInterfaces
{
    public interface IStatusService
    {
        public Task<int> GetStatusId(string status);

    }
}
