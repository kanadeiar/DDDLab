using Sample2.QuestionnaireSubn.Contract.EventSourcing.Abstractions;
using Sample2.QuestionnaireSubn.Contract.EventSourcing.Base;

namespace Sample2.QuestionnaireSubn.Contract.EventSourcing;

public abstract class AggregateRoot
{
    private readonly List<DomainEvent> _changes = new();

    public abstract IIdentity Id { get; }

    public int Version { get; protected set; }

    public void LoadsFromHistory(ICollection<DomainEvent> history)
    {
        foreach (var @event in history) Mutate(@event);
    }

    public ICollection<DomainEvent> Changes() => _changes;
    public void Reset() => _changes.Clear();

    protected void ApplyChange(DomainEvent @event)
    {
        Mutate(@event);
        _changes.Add(@event);
    }

    protected abstract void Mutate(DomainEvent @event);
}