using AutoMapper;
using Ecommerce.Core.Entites;

namespace Ecommerce.Api.Dtos.MappingProfiles
{
    public class MappingCategorey : Profile
    {
        public MappingCategorey()
        {
            CreateMap<Category, CategoreyDTO>().ReverseMap();

            CreateMap<Category, CreateCategoryDTO>().ReverseMap();

        }
    }
}
