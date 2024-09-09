using Ecommerce.Api.Base;
using Ecommerce.Application.Featuers.UserFeatuer.Command.AddUser;
using Ecommerce.Domain.AppMetaData;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [ApiController]
    public class UserController : AppController
    {

        [HttpPost(Routre.UserRouting.Create)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] AddUserCommand command)
        {
            var response = await Mediator.Send(command);

            return NewResult(response);
        }







    }
}
