using Microsoft.AspNetCore.Mvc;


namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {




        /* private readonly ICategoryServices _categoryService;

         public CategoriesController(ICategoryServices categoryService)
         {
             _categoryService = categoryService;
         }

         [HttpGet]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status404NotFound)]
         public async Task<ActionResult<IEnumerable<CategoreyDTO>>> GetAllCategories()
         {
             var categoriesDto = await _categoryService.GetAllCategoreis();

             if (!categoriesDto.Any())
                 return NotFound("No categories found.");

             return Ok(categoriesDto);
         }


         [HttpGet]
         [Route("{Id}")]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status404NotFound)]
         public async Task<ActionResult<CategoreyDTO>> GetCategoryById(int Id)
         {
             var CategoryDTO = await _categoryService.GetCategoreyById(Id);

             if (CategoryDTO == null)
                 return NotFound($"No Categorey with ID: {Id} Found!");

             return Ok(CategoryDTO);
         }


         [HttpPost]
         [Route("AddCategorey")]
         [ProducesResponseType(StatusCodes.Status201Created)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
         [ProducesResponseType(StatusCodes.Status500InternalServerError)]
         public async Task<ActionResult> AddCategorey([FromBody] CategoryToAddDTO CreateCategoryDTO)
         {
             if (!ModelState.IsValid)
                 return BadRequest("Category Data Not Valied");

             bool isAdded = await _categoryService.CreateCategorey(CreateCategoryDTO);

               if (isAdded)
                    return Ok("Category saved successfully.");
               else
                    return BadRequest("Category Data Not Valied");
         }


         [HttpPut]
         [Route("UpdateCategorey")]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status404NotFound)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
         [ProducesResponseType(StatusCodes.Status500InternalServerError)]
         public async Task<ActionResult> UpdateCategorey([FromBody] CategoryToUpdateDTO categoryToUpdateDTO)
         {

             if (!ModelState.IsValid)
                 return BadRequest("Category Data Not Valied");

             bool isUpdated = await _categoryService.UpdateCategorey(categoryToUpdateDTO);

             if (isUpdated)
                 return Ok("Category saved successfully.");
             else
                 return BadRequest("Category Data Not Valied");

         }



         [HttpDelete]
         [Route("DeleteCategorey/{Id}")]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status404NotFound)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
         public async Task<ActionResult> DeleteCategorey(int Id)
         {
             if (Id <= 0)
                 return BadRequest("Id Not Valied");

             if(!(await _categoryService.IsCategoreyExist(Id)))
                 return NotFound("Product is not found");  


             bool isDeleted = await _categoryService.DeleteCategorey(Id);

             if (isDeleted)
                 return Ok("Category Deleted successfully.");
             else
                 return BadRequest("Category Data Not Valied");

         }*/
    }
}