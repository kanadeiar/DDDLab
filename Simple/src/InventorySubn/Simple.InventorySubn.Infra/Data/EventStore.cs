using Simple.InventorySubn.Contract.Abstractions;
using Simple.InventorySubn.Contract.Base;
using Simple.InventorySubn.Domain.Abstractions;

namespace Simple.InventorySubn.Infra.Data;

public class EventStore(IEventPublisher publisher) : IEventStore
{
    private readonly Dictionary<Guid, List<EventDescriptor>> _current = new();

    public void SaveEvents(Guid aggregateId, IEnumerable<Event> events, int expectedVersion)
    {
        if (!_current.TryGetValue(aggregateId, out var descriptors))
        {
            descriptors = new List<EventDescriptor>();
            _current.Add(aggregateId, descriptors);
        }
        else if (descriptors.Last().Version != expectedVersion && expectedVersion != -1)
        {
            throw new ConcurrencyException();
        }
        var i = expectedVersion;

        foreach (var @event in events)
        {
            i++;
            @event.Version = i;

            descriptors.Add(new EventDescriptor(aggregateId, @event, i));
            
            publisher.Publish(@event);
        }
    }

    public List<Event> GetEventsForAggregate(Guid aggregateId)
    {
        if (!_current.TryGetValue(aggregateId, out var descriptors))
        {
            throw new AggregateNotFoundException();
        }

        return descriptors.Select(descriptor => descriptor.EventData).ToList();
    }

    private record EventDescriptor(Guid Id, Event EventData, int Version);

    public class AggregateNotFoundException : Exception;

    public class ConcurrencyException : Exception;
}