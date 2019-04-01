using Switch.Domain.Enums;
using Switch.Domain.Validations;
using System;

namespace Switch.Domain.Commands.Inputs.User
{
    public class RegisterNewUserCommand : UserCommand
    {
        public RegisterNewUserCommand(string firstname, string lastname, string email, string mobile, string password, 
                                        DateTime birthdate, ESexo sexo, string imagem)
        {
            FirstName = firstname;
            LasttName = lastname;
            Email = email;
            Mobile = mobile;
            Password = password;
            Birthdate = birthdate;
            Sexo = sexo;
            ImageUrl = imagem;

        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewUserCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
