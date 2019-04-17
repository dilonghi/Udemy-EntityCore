using Switch.CrossCutting.Shared.Enums;
using Switch.Domain.Core.Events;
using System;

namespace Switch.Domain.Events
{
    public class UserUpdatedEvent : Event
    {
        public UserUpdatedEvent(Guid id, string firstName, string lastName, string email, string mobile, 
                                    string password, DateTime birthdate, ESexo sexo, string imageUrl)
        {
            AggregateId = id;
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Mobile = mobile;
            Password = password;
            Birthdate = birthdate;
            ImageUrl = imageUrl;
        }

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
