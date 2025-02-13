using SimpleCQRS.InventorySub.Domain.Base;

namespace SimpleCQRS.InventorySub.Domain.Events;

public record ItemsCheckedInToInventory(Guid Id, int Count) : Event
{

}