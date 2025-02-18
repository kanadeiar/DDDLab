using Easy.Questionnaire.Contract.EventSourcing.Base;

namespace Easy.Questionnaire.Contract.EventSourcing.Abstractions;

public interface IDispatcher
{
    void Run();

    void RegisterHandler<T>(Action<T> handler)
        where T : DomainEvent;

    void Dispatch(IEnumerable<DomainEvent> events);
}