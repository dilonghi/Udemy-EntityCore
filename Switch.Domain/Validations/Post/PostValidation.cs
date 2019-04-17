using FluentValidation;
using Switch.Domain.Commands.Inputs.Post;
using System;

namespace Switch.Domain.Validations.Post
{
    public class PostValidation<T> : AbstractValidator<T> where T : PostCommand
    {
        protected void ValidateTitle()
        {
            RuleFor(c => c.Title)
                .NotEmpty().WithMessage("Please ensure you have entered the Title")
                .Length(2, 150).WithMessage("The Title must have between 2 and 150 characters");
            
        }

       

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected static bool HaveMinimumAge(DateTime birthDate)
        {
            return birthDate <= DateTime.Now.AddYears(-18);
        }
    }
}
