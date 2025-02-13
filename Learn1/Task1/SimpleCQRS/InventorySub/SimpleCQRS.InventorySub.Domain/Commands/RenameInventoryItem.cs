using SimpleCQRS.InventorySub.Domain.Base;

namespace SimpleCQRS.InventorySub.Domain.Commands;

public record RenameInventoryItem(Guid InventoryItemId, string NewName, int OriginalVersion) : Command
{

}