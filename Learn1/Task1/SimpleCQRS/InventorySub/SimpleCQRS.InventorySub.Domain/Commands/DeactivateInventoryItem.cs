using SimpleCQRS.InventorySub.Domain.Base;

namespace SimpleCQRS.InventorySub.Domain.Commands;

public record DeactivateInventoryItem(Guid InventoryItemId, int OriginalVersion) : Command
{

}