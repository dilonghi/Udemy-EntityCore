using Switch.Domain.Core.Events;
using Switch.Infra.Data.Context;
using System;
using System.Linq;
using System.Collections.Generic;


namespace Switch.Infra.Data.Repositories.EventSourcing
{
    public class EventStoreSQLRepository : IEventStoreRepository
    {
        private readonly EventStoreSQLContext _context;

        public EventStoreSQLRepository(EventStoreSQLContext context)
        {
            _context = context;
        }

        public IList<StoredEvent> All(Guid aggregateId)
        {
            var result = (from e in _context.StoredEvent where e.AggregateId == aggregateId select e).ToList();
            return result;
        }

        public void Store(StoredEvent theEvent)
        {
            _context.StoredEvent.Add(theEvent);
            _context.SaveChanges();
        }


        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
