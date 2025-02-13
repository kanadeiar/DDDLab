using Simple.InventorySubn.Contract.Base;

namespace Simple.InventorySubn.Domain.Base;

public abstract class AggregateRoot
{
    private readonly List<Event> _changes = new();

    public abstract Guid Id { get; }
    public int Version { get; internal set; }

    public IEnumerable<Event> GetChanges()
    {
        return _changes;
    }

    public void LoadsFromHistory(IEnumerable<Event> history)
    {
        foreach (var e in history) Apply(e);
    }

    protected void ApplyChange(Event @event)
    {
        Apply(@event);
        _changes.Add(@event);
    }

    protected abstract void Apply(Event @event);
}