using MediatR;
using Switch.Domain.Core.Bus;
using Switch.Domain.Core.Commands;
using Switch.Domain.Core.Notifications;
using Switch.Domain.Interfaces.Repositories;

namespace Switch.Domain.CommandHandlers
{
    public class CommandHandler
    {
        private readonly IUow _uow;
        private readonly IMediatorHandler _bus;
        private readonly DomainNotificationHandler _notifications;

        public CommandHandler(IUow uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications) 
        {
            _uow = uow;
            _notifications = (DomainNotificationHandler)notifications;
            _bus = bus;
        }

        protected void NotifyValidationErrors(Command message)
        {
            foreach (var error in message.ValidationResult.Errors)
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, error.ErrorMessage));
            }
        }

        public bool Commit()
        {
            if (_notifications.HasNotifications()) return false;
            if (_uow.Commit()) return true;

            _bus.RaiseEvent(new DomainNotification("Commit", "We had a problem during saving your data."));
            return false;
        }
    }
}
