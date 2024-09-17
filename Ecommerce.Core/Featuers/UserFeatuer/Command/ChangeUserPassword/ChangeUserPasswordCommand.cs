using AutoMapper;
using Ecommerce.Application.Common.BaseResponse;
using Ecommerce.Domain.Entites.Identity;
using MediatR;

namespace Ecommerce.Application.Featuers.UserFeatuer.Command.ChangeUserPassword
{
    public class ChangeUserPasswordCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }

        public class UpdateUserProfile : Profile
        {
            public UpdateUserProfile()
            {
                CreateMap<ChangeUserPasswordCommand, User>();
            }
        }
    }
}
