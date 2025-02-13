using Simple.InventorySubn.Application.Abstractions;
using Simple.InventorySubn.Contract.ReadModel;
using Simple.InventorySubn.Domain.Abstractions;
using Simple.InventorySubn.Domain.InventoryAggregate.Events;

namespace Simple.InventorySubn.Application.ReadModel.Views;

public class InventoryItemDetailView(IReadModelStorage storage) : IHandles<InventoryItemCreated>, IHandles<InventoryItemRenamed>,
    IHandles<InventoryItemDeactivated>, IHandles<ItemsRemovedFromInventory>, IHandles<ItemsCheckedInToInventory>, IHandles<MaxQtyChanged>
{
    public void Handle(InventoryItemCreated message)
    {
        storage.Details.Add(message.Id, new InventoryItemDetailsDto(message.Id, message.Name, message.MaxQty, 0, 0));
    }

    public void Handle(InventoryItemRenamed message)
    {
        var details = getDetailsItem(message.Id);
        details.Name = message.NewName;
        details.Version = message.Version;
    }

    public void Handle(InventoryItemDeactivated message)
    {
        storage.Details.Remove(message.Id);
    }

    public void Handle(ItemsRemovedFromInventory message)
    {
        var details = getDetailsItem(message.Id);
        details.CurrentCount -= message.Count;
        details.Version = message.Version;
    }

    public void Handle(ItemsCheckedInToInventory message)
    {
        var details = getDetailsItem(message.Id);
        details.CurrentCount += message.Count;
        details.Version = message.Version;
    }

    public void Handle(MaxQtyChanged message)
    {
        var details = getDetailsItem(message.Id);
        details.MaxQty = message.NewMaxQty;
        details.Version = message.Version;
    }

    private InventoryItemDetailsDto getDetailsItem(Guid id)
    {
        if (!storage.Details.TryGetValue(id, out var details))
        {
            throw new InvalidOperationException("Не удалось найти элемент в базе данных");
        }

        return details;
    }
}