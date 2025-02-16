using Simple.InventorySubn.Domain.InventoryAggregate.Events;

namespace Simple.InventorySubn.Domain.ReadModel;

public record InventoryItemListProjection(Guid Id, string Name)
{
    public InventoryItemListProjection Apply(InventoryItemRenamed ev)
    {
        return this with { Name = ev.NewName };
    }
}