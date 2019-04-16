using AutoMapper;
using Switch.Appilcation.ViewModels;
using Switch.Domain.Entities;

namespace Switch.Appilcation.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<User, UserViewModel>()
                .ForMember(dest => dest.FirstName, opts => opts.MapFrom(src => src.Name.FirstName))
                .ForMember(dest => dest.LastName, opts => opts.MapFrom(src => src.Name.LastName))
                .ForMember(dest => dest.Email, opts => opts.MapFrom(src => src.Email.Address));
        }
    }
}
