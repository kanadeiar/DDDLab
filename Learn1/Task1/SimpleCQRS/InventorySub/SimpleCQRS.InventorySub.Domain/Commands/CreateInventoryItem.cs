using SimpleCQRS.InventorySub.Domain.Base;

namespace SimpleCQRS.InventorySub.Domain.Commands;

public record CreateInventoryItem(Guid InventoryItemId, int OriginalVersion) : Command
{
    
}