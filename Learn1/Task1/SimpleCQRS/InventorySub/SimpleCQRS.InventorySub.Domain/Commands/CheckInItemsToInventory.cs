using SimpleCQRS.InventorySub.Domain.Base;

namespace SimpleCQRS.InventorySub.Domain.Commands;

public record CheckInItemsToInventory(Guid InventoryItemId, int Count, int OriginalVersion) : Command
{

}