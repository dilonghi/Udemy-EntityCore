using Switch.Domain.Commands.Inputs.User;

namespace Switch.Domain.Validations.User
{
    public class RemoveUserCommandValidation : UserValidation<RemoveUserCommand>
    {
        public RemoveUserCommandValidation()
        {
            ValidateId();
           
        }
    }
}
