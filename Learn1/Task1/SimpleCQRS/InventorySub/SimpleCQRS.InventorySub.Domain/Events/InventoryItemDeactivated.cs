using SimpleCQRS.InventorySub.Domain.Base;

namespace SimpleCQRS.InventorySub.Domain.Events;

public record InventoryItemDeactivated(Guid Id) : Event
{

}