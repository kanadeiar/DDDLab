using Easy.Questionnaire.Contract.EventSourcing.Abstractions;
using Easy.Questionnaire.Contract.EventSourcing.Base;

namespace Easy.Questionnaire.Contract.EventSourcing;

public abstract class AggregateRoot
{
    private readonly List<DomainEvent> _changes = new();

    public abstract IIdentity AggregateId { get; }

    public int Version { get; protected set; } = -1;

    public void Load(EventStream stream)
    {
        foreach (var @event in stream.Events) Mutate(@event);
        Version = stream.Version;
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