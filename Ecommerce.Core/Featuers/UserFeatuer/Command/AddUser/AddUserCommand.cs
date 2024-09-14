using AutoMapper;
using Ecommerce.Application.Common.BaseResponse.GenericApiResponse;
using Ecommerce.Domain.Entites;
using MediatR;

namespace Ecommerce.Application.Featuers.UserFeatuer.Command.AddUser
{
    public class AddUserCommand : IRequest<Response<object>>
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }

        public class AddUserCommandProfile : Profile
        {
            public AddUserCommandProfile()
            {
                CreateMap<AddUserCommand, User>();
            }
        }
    }
}
