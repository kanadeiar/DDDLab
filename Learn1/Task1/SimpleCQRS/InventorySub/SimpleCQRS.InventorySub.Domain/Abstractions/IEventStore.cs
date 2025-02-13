using SimpleCQRS.InventorySub.Domain.Base;

namespace SimpleCQRS.InventorySub.Domain.Abstractions;

public interface IEventStore
{
    void SaveEvents(Guid aggregateId, IEnumerable<Event> events, int expectedVersion);

    List<Event> GetEventsForAggregate(Guid aggregateId);
}