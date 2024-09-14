using Ecommerce.Api.Controllers.Base;
using Ecommerce.Application.Featuers.UserFeatuer.Command.AddUser;
using Ecommerce.Application.Featuers.UserFeatuer.Command.ChangeUserPassword;
using Ecommerce.Application.Featuers.UserFeatuer.Command.DeleteUserById;
using Ecommerce.Application.Featuers.UserFeatuer.Command.UpdateUserById;
using Ecommerce.Application.Featuers.UserFeatuer.Queries.GetPaginatedUserList;
using Ecommerce.Application.Featuers.UserFeatuer.Queries.GetUserById;
using Ecommerce.Domain.AppMetaData;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [ApiController]
    public class UserController : AppController
    {


        [HttpGet(Routre.UserRouting.PaginatedList)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUserList(
            [FromQuery] int PageNumber,
            [FromQuery] int PageSize,
            [FromQuery] string? Filters,
            [FromQuery] string? Sorts)
        {
            var response = await Mediator.Send(new GetPaginatedUserListQuery(Sorts, Filters, PageNumber, PageSize));

            return NewResult(response);
        }


        [HttpGet(Routre.UserRouting.GetById)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserById(
            [FromRoute] int Id)
        {
            var response = await Mediator.Send(new GetUserByIdQuery(Id));

            return NewResult(response);
        }



        [HttpPost(Routre.UserRouting.Create)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUser([FromBody] AddUserCommand command)
        {
            var response = await Mediator.Send(command);

            return NewResult(response);
        }


        [HttpPatch(Routre.UserRouting.Update)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserbyIdCommand command)
        {
            var response = await Mediator.Send(command);

            return NewResult(response);
        }


        [HttpPatch(Routre.UserRouting.ChangePassword)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ChangeUserPassword([FromBody] ChangeUserPasswordCommand command)
        {
            var response = await Mediator.Send(command);

            return NewResult(response);
        }


        [HttpDelete(Routre.UserRouting.Delete)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteUser([FromRoute] int Id)
        {
            var response = await Mediator.Send(new DeleteUserByIdCommand(Id));

            return NewResult(response);
        }
    }
}
