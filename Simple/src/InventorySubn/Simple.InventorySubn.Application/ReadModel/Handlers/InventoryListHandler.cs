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
        storage.List.Add(new InventoryItemListProjection(message.Id, message.Name));
    }

    public void Handle(InventoryItemRenamed message)
    {
        var item = storage.List.Find(x => x.Id == message.Id);
        var newest = item.Apply(message);
        var index = storage.List.IndexOf(item);
        storage.List[index] = newest;
    }

    public void Handle(InventoryItemDeactivated message)
    {
        storage.List.RemoveAll(x => x.Id == message.Id);
    }
}