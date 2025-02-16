using Simple.InventorySubn.Application.Abstractions;
using Simple.InventorySubn.Domain.Abstractions;
using Simple.InventorySubn.Domain.InventoryAggregate.Events;
using Simple.InventorySubn.Domain.ReadModel;

namespace Simple.InventorySubn.Application.ReadModel.Handlers;

public class InventoryListHandler(IReadModelStorage storage) : IHandles<InventoryItemCreated>, IHandles<InventoryItemRenamed>,
    IHandles<InventoryItemDeactivated>
{
    public void Handle(InventoryItemCreated message)
    {
        var item = storage.List.Find(x => x.Id == message.Id);
        if (item is not { } found)
        {
            storage.List.Add(new InventoryItemListProjection(message.Id, message.Name));
        }
    }

    public void Handle(InventoryItemRenamed message)
    {
        var item = storage.List.Find(x => x.Id == message.Id);
        if (item is not { } found)
        {
            throw new KeyNotFoundException(nameof(item));
        }
        var index = storage.List.IndexOf(found);
        var newest = found.Apply(message);
        storage.List[index] = newest;
    }

    public void Handle(InventoryItemDeactivated message)
    {
        storage.List.RemoveAll(x => x.Id == message.Id);
    }
}