using AutoMapper;
using Switch.Appilcation.ViewModels;
using Switch.Domain.Entities;

namespace Switch.Appilcation.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<User, UserViewModel>();

            CreateMap<Post, PostViewModel>();
        }
    }
}
