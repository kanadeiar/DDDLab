using Kanadeiar.Common;
using Simple.InventorySubn.Application.ReadModel;
using Simple.InventorySubn.Domain.InventoryAggregate.Commands;
using Simple.InventorySubn.Infra.Data;
using SimpleApp1;

ConsoleHelper.PrintHeader("Опытно-экспериментальное приложение.", "Опыты с DDD.");
ConsoleHelper.PrintLine("Наработка практического опыта CQRS + ES");

var storage = new ReadModelStorage();
var model = new ReadModel(storage);
ServiceLocator.InitBus(storage);

ServiceLocator.SeedTestData();

Console.WriteLine("Произведено заполнение тестовыми данными");
ConsoleHelper.Pause();

var all = model.GetInventoryItems().ToArray();
Console.WriteLine("Все элементы:");
foreach (var each in all)
{
    Console.WriteLine($"{each.Id} {each.Name}");
}

Console.WriteLine("Первый:");
var first = model.GetInventoryItemDetails(all.First().Id);
Console.WriteLine($"{first.Id} {first.Name} max: {first.MaxQty} curr: {first.CurrentCount} {first.Version}");
ServiceLocator.Bus.Send(new CheckInItemsToInventory(first.Id, 5, first.Version));

ConsoleHelper.Pause();

Console.WriteLine("После изменения:");
first = model.GetInventoryItemDetails(all.First().Id);
Console.WriteLine($"{first.Id} {first.Name} max: {first.MaxQty} curr: {first.CurrentCount} {first.Version}");

ConsoleHelper.PrintFooter();
