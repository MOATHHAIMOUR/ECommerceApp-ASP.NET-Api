using AutoMapper;
using Ecommerce.Application.Common.BaseResponse.GenericApiResponse;
using Ecommerce.Domain.Entites;
using MediatR;

namespace Ecommerce.Application.Featuers.UserFeatuer.Command.UpdateUserById
{
    public class UpdateUserbyIdCommand : IRequest<Response<object>>
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }

        public class UpdateUserProfile : Profile
        {
            public UpdateUserProfile()
            {
                CreateMap<UpdateUserbyIdCommand, User>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                    .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                    .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                    .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
                    .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber));
            }
        }
    }
}
