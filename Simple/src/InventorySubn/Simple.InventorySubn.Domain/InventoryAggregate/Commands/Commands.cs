using Simple.InventorySubn.Contract.Base;

namespace Simple.InventorySubn.Domain.InventoryAggregate.Commands;

public record CreateInventoryItem(Guid InventoryItemId, string Name) : Command;

public record DeactivateInventoryItem(Guid InventoryItemId, int OriginalVersion) : Command;

public record RenameInventoryItem(Guid InventoryItemId, string NewName, int OriginalVersion) : Command;

public record CheckInItemsToInventory(Guid InventoryItemId, int Count, int OriginalVersion) : Command;

public record RemoveItemsFromInventory(Guid InventoryItemId, int Count, int OriginalVersion) : Command;

public record ChangeMaxQty(Guid InventoryItemId, int NewMaxQty, int OriginalVersion) : Command;

