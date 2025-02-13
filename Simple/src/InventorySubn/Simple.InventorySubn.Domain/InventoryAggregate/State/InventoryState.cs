using Simple.InventorySubn.Contract.Base;
using Simple.InventorySubn.Domain.InventoryAggregate.Events;

namespace Simple.InventorySubn.Domain.InventoryAggregate.State;

public class InventoryState
{
    public Guid Id { get; private set; }
    public bool Activated { get; private set; }
    public int AvailableQty { get; private set; }
    public int MaxQty { get; private set; } = 5;

    public void Apply(Event @event)
    {
        ((dynamic)this).apply((dynamic)@event);
    }

    private void apply(InventoryItemCreated ev)
    {
        Id = ev.Id;
        Activated = true;
    }

    private void apply(InventoryItemDeactivated ev)
    {
        Activated = false;
    }

    private void apply(ItemsCheckedInToInventory e)
    {
        AvailableQty += e.Count;
    }

    private void apply(ItemsRemovedFromInventory e)
    {
        AvailableQty -= e.Count;
    }

    private void apply(MaxQtyChanged e)
    {
        MaxQty = e.NewMaxQty;
    }
}