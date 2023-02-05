using Application.Common.Management.Task;
using Application.Common.Management.Task.Commands;
using Application.Common.Management.Task.Queries;
using Microsoft.AspNetCore.Mvc;

namespace TaskOrganizationAPI.Controllers.Task
{
    public class TaskController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<SimpleTaskDto>>> Index([FromQuery] GetProjectTasksQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task<ActionResult<List<Domain.Entities.User.User>>> Index([FromBody] CreateTaskDto taskDto)
        {
            var project = await Mediator.Send(new CreateTaskCommand(taskDto));
            return Ok(project);
        }
    }
}
