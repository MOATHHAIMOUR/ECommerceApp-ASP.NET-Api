using AutoMapper;
using Ecommerce.Api.Dtos;
using Ecommerce.Core;
using Ecommerce.Core.Entites;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Product>> GetAllProduct()
        {
            var Products = await _unitOfWork.ProductrRepository
                .GetAllAsync(null,null,"Category");

            if (Products == null || !Products.Any())
                return NotFound();

            //mapping to Product DTO 
            var Productstos = Products.Select(p =>
            {
                return new ProductDTO
                {
                    Id = p.Id,  
                    Name = p.Name,
                    CategoryName = p.Category.Name,
                    Description = p.Description,
                    Price = p.Price 
                };
            });

            return Ok(Productstos);
        }

/*
        [HttpGet]
        [Route("{Id}")]
        public async Task<ActionResult<Product>> GetProductById(int Id)
        {
            Product ptoduct = await unitOfWork.ProductrRepository
                .GetById(Id);

            if(ptoduct is null)
                return NotFound($"Product with Id: {Id} is Not Found !");

            
        }
*/


    }
}
