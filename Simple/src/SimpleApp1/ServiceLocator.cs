using Simple.InventorySubn.Application.Handlers;
using Simple.InventorySubn.Application.ReadModel.Handlers;
using Simple.InventorySubn.Domain.InventoryAggregate;
using Simple.InventorySubn.Domain.InventoryAggregate.Commands;
using Simple.InventorySubn.Domain.InventoryAggregate.Events;
using Simple.InventorySubn.Infra.Bus;
using Simple.InventorySubn.Infra.Data;

namespace SimpleApp1;

public static class ServiceLocator
{
    public static void InitBus(ReadModelStorage readModelStorage)
    {
        var bus = new FakeBus();
        var storage = new EventStore(bus);
        var repo = new Repository<Inventory>(storage);
        var commands = new InventoryCommandHandlers(repo);
        bus.RegisterHandler<CreateInventoryItem>(commands.Handle);
        bus.RegisterHandler<DeactivateInventoryItem>(commands.Handle);
        bus.RegisterHandler<RenameInventoryItem>(commands.Handle);
        bus.RegisterHandler<CheckInItemsToInventory>(commands.Handle);
        bus.RegisterHandler<RemoveItemsFromInventory>(commands.Handle);
        bus.RegisterHandler<ChangeMaxQty>(commands.Handle);
        var detail = new InventoryItemDetailHanlder(readModelStorage);
        bus.RegisterHandler<InventoryItemCreated>(detail.Handle);
        bus.RegisterHandler<InventoryItemDeactivated>(detail.Handle);
        bus.RegisterHandler<InventoryItemRenamed>(detail.Handle);
        bus.RegisterHandler<ItemsCheckedInToInventory>(detail.Handle);
        bus.RegisterHandler<ItemsRemovedFromInventory>(detail.Handle);
        bus.RegisterHandler<MaxQtyChanged>(detail.Handle);
        var list = new InventoryListHandler(readModelStorage);
        bus.RegisterHandler<InventoryItemCreated>(list.Handle);
        bus.RegisterHandler<InventoryItemRenamed>(list.Handle);
        bus.RegisterHandler<InventoryItemDeactivated>(list.Handle);
        Bus = bus;
    }

    public static void SeedTestData()
    {
        Bus.Send(new CreateInventoryItem(Guid.NewGuid(), "Тестовое место 1"));
        Bus.Send(new CreateInventoryItem(Guid.NewGuid(), "Тестовое место 2"));
        Bus.Send(new CreateInventoryItem(Guid.NewGuid(), "Тестовое место 3"));
    }


    public static FakeBus Bus { get; set; }
}