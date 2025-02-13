using Kanadeiar.Common;
using Simple.InventorySubn.Application.ReadModel;
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

Console.WriteLine("Все элементы:");
foreach (var each in model.GetInventoryItems())
{
    Console.WriteLine($"{each.Id} {each.Name}");
}

ConsoleHelper.PrintFooter();
