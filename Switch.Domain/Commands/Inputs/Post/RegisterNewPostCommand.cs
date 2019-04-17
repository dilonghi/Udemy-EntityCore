using Switch.Domain.Validations.Post;
using System;

namespace Switch.Domain.Commands.Inputs.Post
{
    public class RegisterNewPostCommand : PostCommand
    {
        public RegisterNewPostCommand(string title, Guid userId, int groupId, string contentUrl)
        {
            Title = title;
            UserId = userId;
            GroupId = groupId;
            ContentUrl = contentUrl;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewPostCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
