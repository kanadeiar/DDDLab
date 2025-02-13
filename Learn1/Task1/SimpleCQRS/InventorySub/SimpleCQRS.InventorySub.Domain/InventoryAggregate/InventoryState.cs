using SimpleCQRS.InventorySub.Domain.Base;
using SimpleCQRS.InventorySub.Domain.Events;

namespace SimpleCQRS.InventorySub.Domain.InventoryAggregate;

public class InventoryState
{
    public Guid Id { get; private set; }

    public bool Activated { get; private set; }

    public int AvailableQty { get; private set; }

    public int MaxQty { get; private set; } = 5;

    private void Apply(InventoryItemCreated ev)
    {
        Id = ev.Id;
        Activated = true;
    }

    private void Apply(InventoryItemDeactivated ev)
    {
        Activated = false;
    }

    private void Apply(MaxQtyChanged ev)
    {
        MaxQty = ev.NewMaxQty;
    }

    private void Apply(ItemsCheckedInToInventory e)
    {
        AvailableQty += e.Count;
    }

    private void Apply(ItemsRemovedFromInventory e)
    {
        AvailableQty -= e.Count;
    }

    public void ApplyChange(Event @event) => ((dynamic)this).Apply((dynamic)@event);
}