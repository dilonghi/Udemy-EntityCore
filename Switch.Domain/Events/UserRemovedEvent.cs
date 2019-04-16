using Switch.Domain.Core.Events;
using System;

namespace Switch.Domain.Events
{
    public class UserRemoveEvent : Event
    {
        public UserRemoveEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}
