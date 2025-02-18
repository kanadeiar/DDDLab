using Easy.Questionnaire.Contract.EventSourcing.Base;

namespace Easy.Questionnaire.Contract.EventSourcing.Abstractions;

public interface IEventStore
{
    EventStream LoadEventStream(IIdentity id);

    void AppendToStream(IIdentity id, ICollection<DomainEvent> changes, int expectedVersion);
}