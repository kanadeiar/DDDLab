using SimpleCQRS.InventorySub.Domain.Base;

namespace SimpleCQRS.InventorySub.Domain.Events;

public record InventoryItemRenamed(Guid Id, string NewName) : Event
{

}