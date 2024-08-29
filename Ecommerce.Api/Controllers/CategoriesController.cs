using Ecommerce.Api.Dtos;
using Ecommerce.Core;
using Ecommerce.Core.Entites;
using Microsoft.AspNetCore.Mvc;


namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public CategoriesController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ListingCategoreyDTO>>> GetAllCategories()
        {
            var allCategories = await unitOfWork.CategoreyRepository.GetAllAsync();

            if (allCategories == null || !allCategories.Any())
                return NotFound("No categories found.");

            var categoreyDTOs = allCategories.Select(Categorey =>(ListingCategoreyDTO)Categorey); 

            return Ok(categoreyDTOs);  
        }


        [HttpGet]
        [Route("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ListingCategoreyDTO>> GetCategoryById(int Id)
        {
            var Category = await unitOfWork.CategoreyRepository.GetById(Id);

            if (Category is null)
                return NotFound($"No Categorey with ID: {Id} Found!");

            var CategoryDTO = new ListingCategoreyDTO()
            { 
                Id = Id,
                Name = Category.Name, 
                Description = Category.Description
            }; 
            
            return Ok(CategoryDTO);
        }


        [HttpPost]
        [Route("AddCategorey")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> AddCategorey([FromBody] CategoreyDTO category)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Category Data Not Valied");

                var newCategorey = new Category()
                {
                    Name = category.Name,
                    Description = category.Description,
                };

                await unitOfWork.CategoreyRepository.AddAsync(newCategorey);

                var result = await unitOfWork.CommitAsync();

                if (result > 0)
                    return Ok("Category saved successfully.");
                else
                    return StatusCode(StatusCodes.Status500InternalServerError, "Category could not be saved.");
            }
            catch (Exception ex) 
            {
                // Log the exception details for further investigation (using a logging framework like Serilog, NLog, etc.)
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while saving the category.");
            }

        }


        [HttpPut]
        [Route("UpdateCategorey/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateCategorey([FromBody] UpdatedCategoreyDTO updatedCategoryDTO)
        {
            if (updatedCategoryDTO.Id <= 0 || !ModelState.IsValid)
                return BadRequest("Category Data Not Valied");

            try
            {
                var IsExist = await unitOfWork.CategoreyRepository.GetById(updatedCategoryDTO.Id);

                if (IsExist is null)
                    return NotFound($"No Categorey with ID: {updatedCategoryDTO.Id} Found!");

                // Update the existing category with new values
                var updatedCategorey = updatedCategoryDTO.ToModel();

                await unitOfWork.CategoreyRepository.UpdateAsync(IsExist);

                var result = await unitOfWork.CommitAsync();

                if (result > 0)
                    return Ok("Category updated successfully.");
                else
                    return StatusCode(StatusCodes.Status500InternalServerError, "Category could not be saved.");

            }
            catch(Exception ex)
            {
                // Log the exception details for further investigation (using a logging framework like Serilog, NLog, etc.)
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while saving the category. {ex.Message}");
            }

        }



        [HttpDelete]
        [Route("DeleteCategorey/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteCategorey(int Id)
        {
            if (Id <= 0)
                return BadRequest("Id Not Valied");

            try
            {
                var category = unitOfWork.CategoreyRepository.GetById(Id);

                if (category == null)
                    return NotFound($"Category with ID: {Id} not found.");

                await unitOfWork.CategoreyRepository.DeleteAsync(Id); 

                var result = await unitOfWork.CommitAsync();

                if (result > 0)
                    return Ok("Category Deleted successfully.");
                else
                    return StatusCode(StatusCodes.Status500InternalServerError, "Category could not be saved.");

            }
            catch (Exception ex)
            {
                // Log the exception details for further investigation (using a logging framework like Serilog, NLog, etc.)
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while saving the category. {ex.Message}");
            }

        }
    }
}