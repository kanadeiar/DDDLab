using Simple.InventorySubn.Application.Abstractions;
using Simple.InventorySubn.Domain.Abstractions;
using Simple.InventorySubn.Domain.InventoryAggregate.Events;
using Simple.InventorySubn.Domain.ReadModel;

namespace Simple.InventorySubn.Application.ReadModel.Handlers;

public class InventoryItemDetailHanlder(IReadModelStorage storage) : IHandles<InventoryItemCreated>, IHandles<InventoryItemRenamed>,
    IHandles<InventoryItemDeactivated>, IHandles<ItemsRemovedFromInventory>, IHandles<ItemsCheckedInToInventory>, IHandles<MaxQtyChanged>
{
    public void Handle(InventoryItemCreated message)
    {
        storage.Details.Add(message.Id, new InventoryItemDetailsProjection(message.Id, message.Name, message.MaxQty, 0, 0));
    }

    public void Handle(InventoryItemRenamed message)
    {
        var details = getDetailsItem(message.Id);
        var newest = details.Apply(message);
        storage.Details[message.Id] = newest;
    }

    public void Handle(InventoryItemDeactivated message)
    {
        storage.Details.Remove(message.Id);
    }

    public void Handle(ItemsRemovedFromInventory message)
    {
        var details = getDetailsItem(message.Id);
        var newest = details.Apply(message);
        storage.Details[message.Id] = newest;
    }

    public void Handle(ItemsCheckedInToInventory message)
    {
        var details = getDetailsItem(message.Id);
        var newest = details.Apply(message);
        storage.Details[message.Id] = newest;
    }

    public void Handle(MaxQtyChanged message)
    {
        var details = getDetailsItem(message.Id);
        var newest = details.Apply(message);
        storage.Details[message.Id] = newest;
    }

    private InventoryItemDetailsProjection getDetailsItem(Guid id)
    {
        if (!storage.Details.TryGetValue(id, out var details))
        {
            throw new InvalidOperationException("Не удалось найти элемент в базе данных");
        }

        return details;
    }
}