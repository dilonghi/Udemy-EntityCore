using Switch.Domain.Commands.Inputs.User;

namespace Switch.Domain.Validations
{
    public class RemoveUserCommandValidation : UserValidation<RemoveUserCommand>
    {
        public RemoveUserCommandValidation()
        {
            ValidateId();
           
        }
    }
}
