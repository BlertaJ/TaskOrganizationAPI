using System.Net;

namespace Application.Common.Management
{
    public class TaskManagementResponseModel<T> where T : class
    {
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public List<T> Data { get; set; }
    }
}
