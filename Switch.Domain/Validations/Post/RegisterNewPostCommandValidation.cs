using Switch.Domain.Commands.Inputs.Post;

namespace Switch.Domain.Validations.Post
{
    public class RegisterNewPostCommandValidation : PostValidation<RegisterNewPostCommand>
    {
        public RegisterNewPostCommandValidation()
        {
            ValidateTitle();
        }
    }
}
