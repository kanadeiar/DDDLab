using Simple.InventorySubn.Contract.Base;

namespace Simple.InventorySubn.Contract.Abstractions;

public interface IEventStore
{
    void SaveEvents(Guid aggregateId, IEnumerable<Event> events, int expectedVersion);

    List<Event> GetEventsForAggregate(Guid aggregateId);
}