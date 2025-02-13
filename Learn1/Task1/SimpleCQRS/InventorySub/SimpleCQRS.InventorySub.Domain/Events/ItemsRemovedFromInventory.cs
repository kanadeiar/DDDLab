using SimpleCQRS.InventorySub.Domain.Base;

namespace SimpleCQRS.InventorySub.Domain.Events;

public record ItemsRemovedFromInventory(Guid Id, int Count) : Event
{

}