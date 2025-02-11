using Task1.CustomerSub.Domain.Abstractions;

namespace Task1.CustomerSub.Application.Abstractions;

public interface IEventStore
{
    EventStream LoadEventStream(IIdentity id);

    EventStream LoadEventStream(IIdentity id, int skip, int count);

    void AppendToStream(IIdentity id, int expectedVersion, ICollection<IEvent> events);
}

public class EventStream
{
    public int Version;

    public List<IEvent> Events;
}