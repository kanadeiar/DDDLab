using SimpleCQRS.InventorySub.Domain.Base;

namespace SimpleCQRS.InventorySub.Domain.Commands;

public record ChangeMaxQty(Guid InventoryItemId, int NewMaxQty, int OriginalVersion) : Command
{

}