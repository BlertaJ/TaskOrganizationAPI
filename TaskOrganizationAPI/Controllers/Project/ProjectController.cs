using Application.Common.Management.Queries;
using Domain.Entities.Project;
using Microsoft.AspNetCore.Mvc;

namespace TaskOrganizationAPI.Controllers
{
    public class ProjectController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Project>>> Index([FromQuery] GetProjectsQuery query)
        {
            return await Mediator.Send(query);
        }
    }
}
