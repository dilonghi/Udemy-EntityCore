using Switch.CrossCutting.Shared.Enums;
using Switch.Domain.Core.Commands;
using System;

namespace Switch.Domain.Commands.Inputs.User
{
    public abstract class UserCommand : Command
    {
        public Guid Id { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string Email { get; protected set; }
        public string Mobile { get; protected set; }
        public string Password { get; protected set; }
        public DateTime Birthdate { get; protected set; }
        public ESexo Sexo { get; protected set; }
        public string ImageUrl { get; protected set; }
    }
}
