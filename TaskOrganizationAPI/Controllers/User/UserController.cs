using Application.Common.Management.User.Commands;
using Application.Common.Management.User.Queries;
using Microsoft.AspNetCore.Mvc;

namespace TaskOrganizationAPI.Controllers.User
{
    public class UserController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Domain.Entities.User.User>>> Index([FromQuery] GetUsersQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task<ActionResult<List<Domain.Entities.User.User>>> Index([FromBody] CreateUserDto userDto)
        {
            var project = await Mediator.Send(new CreateUserCommand(userDto));
            return Ok(project);
        }
    }
}
