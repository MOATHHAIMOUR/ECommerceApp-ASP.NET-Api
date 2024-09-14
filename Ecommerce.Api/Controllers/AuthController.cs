using Ecommerce.Api.Controllers.Base;
using Ecommerce.Application.Featuers.AuthenticationFeatuer.Command.SignIn;
using Ecommerce.Domain.AppMetaData;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [ApiController]
    public class AuthController : AppController
    {

        [HttpPost(Routre.AuthRouting.SignIn)]
        public async Task<IActionResult> SignIn([FromForm] SignInCommand signInCommand)
        {
            var responose = await Mediator.Send(signInCommand);

            return NewResult(responose);
        }

    }
}
