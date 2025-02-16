using Sample2.QuestionnaireSubn.Contract.EventSourcing.Base;

namespace Sample2.QuestionnaireSubn.Contract.EventSourcing.Abstractions;

public interface IEventStore
{
    EventStream LoadEventStream(IIdentity id);

    void AppendToStream(IIdentity id, ICollection<DomainEvent> events, int expectedVersion);
}