using Ecommerce.Core.Entites;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Api.Dtos
{
    public class CategoreyDTO
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }


        public static explicit operator CategoreyDTO (Category category)
        {
            return new CategoreyDTO
            {
                Name = category.Name,
                Description = category.Description,
            };
        }
    }



    public class ListingCategoreyDTO : CategoreyDTO
    {
         public int Id { get; set; }

        public static ListingCategoreyDTO FromModel(Category category)
        {
            return new ListingCategoreyDTO
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };
        }
    }


    public class UpdatedCategoreyDTO : CategoreyDTO
    {
        public int Id { get; set; }

        public Category ToModel()
        {
            return new Category
            {
                Id = this.Id,
                Name = this.Name,
                Description = this.Description
            };
        }
    }


}
