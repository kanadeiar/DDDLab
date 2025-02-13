using Simple.InventorySubn.Domain.Abstractions;
using Simple.InventorySubn.Domain.InventoryAggregate;
using Simple.InventorySubn.Domain.InventoryAggregate.Commands;

namespace Simple.InventorySubn.Application.Handlers;

public class InventoryCommandHandlers(IRepository<Inventory> repository)
{
    public void Handle(CreateInventoryItem message)
    {
        var item = new Inventory(message.InventoryItemId, message.Name);
        repository.Save(item, -1);
    }

    public void Handle(DeactivateInventoryItem message)
    {
        var item = repository.GetById(message.InventoryItemId);
        item.Deactivate();
        repository.Save(item, message.OriginalVersion);
    }

    public void Handle(RemoveItemsFromInventory message)
    {
        var item = repository.GetById(message.InventoryItemId);
        item.Remove(message.Count);
        repository.Save(item, message.OriginalVersion);
    }

    public void Handle(CheckInItemsToInventory message)
    {
        var item = repository.GetById(message.InventoryItemId);
        item.CheckIn(message.Count);
        repository.Save(item, message.OriginalVersion);
    }

    public void Handle(RenameInventoryItem message)
    {
        var item = repository.GetById(message.InventoryItemId);
        item.ChangeName(message.NewName);
        repository.Save(item, message.OriginalVersion);
    }

    public void Handle(ChangeMaxQty message)
    {
        var item = repository.GetById(message.InventoryItemId);
        item.ChangeMaxQty(message.NewMaxQty);
        repository.Save(item, message.OriginalVersion);
    }
}