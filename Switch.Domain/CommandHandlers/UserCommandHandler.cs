using MediatR;
using Switch.Domain.Commands.Inputs.User;
using Switch.Domain.Core.Bus;
using Switch.Domain.Core.Notifications;
using Switch.Domain.Entities;
using Switch.Domain.Events;
using Switch.Domain.Interfaces.Repositories;
using Switch.Domain.ValueObjects;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Switch.Domain.CommandHandlers
{
    public class UserCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMediatorHandler Bus;

        public UserCommandHandler(IUserRepository userRepository,
                                    IUow uow,
                                    IMediatorHandler bus,
                                    INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _userRepository = userRepository;
            Bus = bus;
        }

        public Task<bool> Handle(RegisterNewUserCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var name = new Name { FirstName = message.FirstName, LastName = message.LastName };
            var email = new Email { Address = message.Email };
            var user = new User(name, email, message.Mobile, message.Password, message.Birthdate, message.Sexo, message.ImageUrl);

            if (_userRepository.GetByEmail(user.Email.Address) != null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "The customer e-mail has already been taken."));
                return Task.FromResult(false);
            }

            _userRepository.Add(user);

            if (Commit())
            {
                Bus.RaiseEvent(new UserRegisteredEvent(user.Id, user.Name.FirstName, user.Name.LastName, user.Email.Address,
                                                        user.Mobile, user.Password, user.Birthdate, user.Sexo, user.ImageUrl));
            }

            return Task.FromResult(true);
        }


        public void Dispose()
        {
            _userRepository.Dispose();
        }
    }
}
