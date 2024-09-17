using Ecommerce.Api.Controllers.Base;
using Ecommerce.Application.Featuers.ProductFeatuer.Command.AddProduct;
using Ecommerce.Application.Featuers.ProductFeatuer.Command.DeleteProductById;
using Ecommerce.Application.Featuers.ProductFeatuer.Command.UpdateProductById;
using Ecommerce.Application.Featuers.ProductFeatuer.Queries.GetProductById;
using Ecommerce.Domain.AppMetaData;
using Ecommerce.Domain.Featuers.ProductFeatuer.Queries.GetProductList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [Authorize]
    [ApiController]
    public class ProductsController : AppController
    {

        [HttpGet(Routre.StudentRouting.PaginatedList)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProductList(
        [FromQuery] int PageNumber,
        [FromQuery] int PageSize,
        [FromQuery] string Filters,
        [FromQuery] string Sotrs
        )
        {

            var response = await Mediator.Send(new GetPaginatedProductListQuery(Sotrs, Filters, PageNumber, PageSize));

            return NewResult(response);
        }


        [HttpGet(Routre.StudentRouting.GetById)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetProductByID([FromRoute] int Id)
        {
            var response = await Mediator.Send(new GetProductByIdQuery(Id));

            return NewResult(response);
        }


        [HttpPost(Routre.StudentRouting.Create)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Create([FromBody] AddProductCommand command)
        {
            var response = await Mediator.Send(command);

            return NewResult(response);
        }

        [HttpPut(Routre.StudentRouting.Update)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Update([FromBody] UpdateProductByIdCommand command)
        {
            var response = await Mediator.Send(command);

            return NewResult(response);
        }

        [HttpDelete(Routre.StudentRouting.Delete)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete([FromRoute] DeleteProductByIdCommand command)
        {
            var response = await Mediator.Send(command);

            return NewResult(response);
        }
    }
}
