using MediatR;
using Switch.Domain.Events;
using System.Threading;
using System.Threading.Tasks;

namespace Switch.Domain.EventHandlers
{
    public class UserEventHandler :
        INotificationHandler<UserRegisteredEvent>
    {
        public Task Handle(UserRegisteredEvent message, CancellationToken cancellationToken)
        {
            // Send some greetings e-mail

            return Task.CompletedTask;
        }
    }

}
