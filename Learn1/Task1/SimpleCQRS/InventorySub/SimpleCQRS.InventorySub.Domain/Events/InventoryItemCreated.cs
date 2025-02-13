using SimpleCQRS.InventorySub.Domain.Base;

namespace SimpleCQRS.InventorySub.Domain.Events;

public record InventoryItemCreated(Guid Id, string Name, int MaxQty) : Event
{

}