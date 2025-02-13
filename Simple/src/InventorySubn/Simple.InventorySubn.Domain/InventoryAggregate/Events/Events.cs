using Simple.InventorySubn.Contract.Base;

namespace Simple.InventorySubn.Domain.InventoryAggregate.Events;

public record InventoryItemCreated(Guid Id, string Name, int MaxQty) : Event;

public record InventoryItemDeactivated(Guid Id) : Event;

public record InventoryItemRenamed(Guid Id, string NewName) : Event;

public record ItemsCheckedInToInventory(Guid Id, int Count) : Event;

public record ItemsRemovedFromInventory(Guid Id, int Count) : Event;

public record MaxQtyChanged(Guid Id, int NewMaxQty) : Event;

