using AutoMapper;
using Switch.Appilcation.ViewModels;
using Switch.Domain.Commands.Inputs.User;

namespace Switch.Appilcation.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<UserViewModel, RegisterNewUserCommand>()
                .ConstructUsing(c => new RegisterNewUserCommand(c.FirstName, c.LastName, c.Email, c.Mobile, c.Password,
                                                                c.Birthdate, c.Sexo, c.ImageUrl));
            
        }
    }
}
