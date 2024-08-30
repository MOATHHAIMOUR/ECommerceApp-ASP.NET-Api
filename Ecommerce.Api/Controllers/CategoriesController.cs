using AutoMapper;
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
        private readonly IMapper _mapper; 


        public CategoriesController(IUnitOfWork unitOfWork, IMapper _mapper)
        {
            this.unitOfWork = unitOfWork;
            this._mapper = _mapper; 
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CategoreyDTO>>> GetAllCategories()
        {
            var allCategories = await unitOfWork.CategoreyRepository.GetAllAsync();

            if (allCategories == null || !allCategories.Any())
                return NotFound("No categories found.");

            var categoreyDTOs = _mapper.Map<IEnumerable<CategoreyDTO>>(allCategories); 

            return Ok(categoreyDTOs);  
        }


        [HttpGet]
        [Route("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategoreyDTO>> GetCategoryById(int Id)
        {
            var Category = await unitOfWork.CategoreyRepository.GetById(Id);

            if (Category is null)
                return NotFound($"No Categorey with ID: {Id} Found!");

            var CategoryDTO = _mapper.Map<CategoreyDTO>(Category);
            
            return Ok(CategoryDTO);
        }


        [HttpPost]
        [Route("AddCategorey")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> AddCategorey([FromBody] CreateCategoryDTO CreateCategoryDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest("Category Data Not Valied");
            try
            {

                var newCategorey = _mapper.Map<Category>(CreateCategoryDTO); 
                
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
        [Route("UpdateCategorey")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateCategorey([FromBody] CategoreyDTO CategoreyDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest("Category Data Not Valied");

            try
            {
                var Categorey = await unitOfWork.CategoreyRepository.GetById(CategoreyDTO.Id);

                if (Categorey == null)
                    return NotFound($"No Categorey with ID: {CategoreyDTO.Id} Found!");

                // Update the existing category with new values
                var updatedCategorey = _mapper.Map<Category>(CategoreyDTO); 

                await unitOfWork.CategoreyRepository.UpdateAsync(updatedCategorey);

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
        [Route("DeleteCategorey/{Id}")]
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
                var category = await unitOfWork.CategoreyRepository.GetById(Id);

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