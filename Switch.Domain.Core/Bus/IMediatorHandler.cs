using Switch.Domain.Core.Commands;
using Switch.Domain.Core.Events;
using System.Threading.Tasks;

namespace Switch.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
