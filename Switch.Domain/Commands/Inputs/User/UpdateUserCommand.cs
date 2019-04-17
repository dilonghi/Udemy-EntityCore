using Switch.CrossCutting.Shared.Enums;
using Switch.Domain.Validations.User;
using System;

namespace Switch.Domain.Commands.Inputs.User
{
    public class UpdateUserCommand : UserCommand
    {
        public UpdateUserCommand(Guid id, string firstname, string lastname, string email, string mobile, string password, 
                                        DateTime birthdate, ESexo sexo, string imagem)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            Mobile = mobile;
            Password = password;
            Birthdate = birthdate;
            Sexo = sexo;
            ImageUrl = imagem;

        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateUserCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
