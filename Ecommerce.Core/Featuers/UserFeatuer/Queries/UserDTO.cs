using AutoMapper;
using Ecommerce.Domain.Entites.Identity;

namespace Ecommerce.Application.Featuers.UserFeatuer.Queries
{
    public class UserDTO
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }

        public class UserDTOProfile : Profile
        {
            public UserDTOProfile()
            {
                CreateMap<User, UserDTO>();
            }
        }
    }
}
