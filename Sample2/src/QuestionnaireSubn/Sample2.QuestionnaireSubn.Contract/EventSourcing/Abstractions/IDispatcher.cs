using Sample2.QuestionnaireSubn.Contract.EventSourcing.Base;

namespace Sample2.QuestionnaireSubn.Contract.EventSourcing.Abstractions;

public interface IDispatcher
{
    void RegisterHandler<T>(Action<T> handler)
        where T : DomainEvent;

    public void Dispatch(IEnumerable<DomainEvent> events);
}