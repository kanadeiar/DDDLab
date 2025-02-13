namespace SimpleCQRS.InventorySub.Domain.Base;

public abstract class AggregateRoot
{
    protected List<Event> Changes = new();

    public abstract Guid Id { get; }
    public int Version { get; private set; }

    public IEnumerable<Event> GetChanges() => Changes;

    public void ResetChanges() => Changes.Clear();

    public void LoadsFromHistory(IEnumerable<Event> history)
    {
        foreach (var e in history) ApplyChange(e, false);
    }

    protected void ApplyChange(Event @event)
    {
        ApplyChange(@event, true);
    }

    protected abstract void ApplyChange(Event @event, bool isNew);
}