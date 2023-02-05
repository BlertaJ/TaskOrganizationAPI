using Application.Common.Management.Project.Commands;
using Application.Common.Management.Project.Queries;
using Application.Common.Management.Queries;
using Domain.Entities.Project;
using Microsoft.AspNetCore.Mvc;

namespace TaskOrganizationAPI.Controllers
{
    public class ProjectController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<SimpleProjectDto>>> Index([FromQuery] GetProjectsQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task<ActionResult<List<Project>>> Index([FromBody] CreateProjectDto productDto)
        {
            var project = await Mediator.Send(new CreateProjectCommand(productDto));

            return Ok(project);
        }
    }
}
