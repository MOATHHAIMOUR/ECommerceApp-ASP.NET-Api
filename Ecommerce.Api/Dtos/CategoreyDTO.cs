using Ecommerce.Core.Entites;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Api.Dtos
{
    public class CategoreyDTO
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Id must be greater than 0.")]
        public int Id { get; set; } 
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

    }

    public class CreateCategoryDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
