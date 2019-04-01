using MediatR;
using Switch.Domain.Commands.Inputs.User;
using Switch.Domain.Core.Bus;
using Switch.Domain.Core.Notifications;
using Switch.Domain.Interfaces.Repositories;
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

        public UserCommandHandler(IUserRepository _userRepository,
                                    IUow uow,
                                    IMediatorHandler bus,
                                    INotificationHandler<DomainNotification> notifications)
            : base(uow, bus, notifications)
        {

        }

        public Task<bool> Handle(RegisterNewUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }


        public void Dispose()
        {
            _userRepository.Dispose();
        }
    }
}
