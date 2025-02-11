using Task1.CustomerSub.Application.Abstractions;
using Task1.CustomerSub.Domain.Abstractions;

namespace Task1.CustomerSub.Infra.Data;

public class EventStore : IEventStore
{
    private readonly Dictionary<IIdentity, EventStream> _events = new();

    public EventStream LoadEventStream(IIdentity id)
    {
        return _events[id];
    }

    public EventStream LoadEventStream(IIdentity id, int skip, int count)
    {
        return _events[id];
    }

    public void AppendToStream(IIdentity id, int expectedVersion, ICollection<IEvent> events)
    {
        var eventStream = _events[id];
        if (eventStream.Version != expectedVersion) throw new ApplicationException("Concurrent Exception");

        eventStream.Events.AddRange(events);
        eventStream.Version = expectedVersion;
    }
}
