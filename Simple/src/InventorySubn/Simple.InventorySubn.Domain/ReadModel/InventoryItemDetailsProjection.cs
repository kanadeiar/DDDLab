using Simple.InventorySubn.Domain.InventoryAggregate.Events;

namespace Simple.InventorySubn.Domain.ReadModel;

public record InventoryItemDetailsProjection(Guid Id, string Name, int MaxQty, int CurrentCount, int Version)
{
    public InventoryItemDetailsProjection Apply(InventoryItemRenamed ev)
    {
        return this with { Name = ev.NewName, Version = ev.Version };
    }    
    
    public InventoryItemDetailsProjection Apply(ItemsCheckedInToInventory ev)
    {
        return this with { CurrentCount = CurrentCount + ev.Count, Version = ev.Version };
    }

    public InventoryItemDetailsProjection Apply(ItemsRemovedFromInventory ev)
    {
        return this with { CurrentCount = CurrentCount - ev.Count, Version = ev.Version };
    }

    public InventoryItemDetailsProjection Apply(MaxQtyChanged ev)
    {
        return this with { MaxQty = ev.NewMaxQty, Version = ev.Version };
    }
}