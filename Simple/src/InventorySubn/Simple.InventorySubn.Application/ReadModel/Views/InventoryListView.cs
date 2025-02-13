using Simple.InventorySubn.Application.Abstractions;
using Simple.InventorySubn.Contract.ReadModel;
using Simple.InventorySubn.Domain.Abstractions;
using Simple.InventorySubn.Domain.InventoryAggregate.Events;

namespace Simple.InventorySubn.Application.ReadModel.Views;

public class InventoryListView(IReadModelStorage storage) : IHandles<InventoryItemCreated>, IHandles<InventoryItemRenamed>,
    IHandles<InventoryItemDeactivated>
{
    public void Handle(InventoryItemCreated message)
    {
        storage.List.Add(new InventoryItemListDto(message.Id, message.Name));
    }

    public void Handle(InventoryItemRenamed message)
    {
        var item = storage.List.Find(x => x.Id == message.Id);
        item.Name = message.NewName;
    }

    public void Handle(InventoryItemDeactivated message)
    {
        storage.List.RemoveAll(x => x.Id == message.Id);
    }
}