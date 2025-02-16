using Kanadeiar.Common;
using Sample2.QuestionnaireSubn.Application.QuestionnaireFunction;
using Sample2.QuestionnaireSubn.Application.ReadModel;
using Sample2.QuestionnaireSubn.Domain.QuestionnaireAggregate;
using Sample2.QuestionnaireSubn.Infra.Data;
using Sample2.QuestionnaireSubn.Infra.ReadModel;
using Sample2.QuestionnaireSubn.Infra.Tools;

ConsoleHelper.PrintHeader("Опытно-экспериментальное приложение.", "Опыты с DDD.");
ConsoleHelper.PrintLine("Наработка практического опыта CQRS + ES");

var dispatcher = new DomainEventDispatcher();
dispatcher.Run();
var store = new EventStore(dispatcher);
var storage = new Storage<Questionnaire>(store);

var readStorage = new ReadModelStorage();
var viewer = new Viewer(readStorage, dispatcher);
viewer.Init();

//DeveloperScript.CreateTestSubscribe(dispatcher);

var service = new QuestionnaireApplicationService(storage);

service.CreateQuestionnaireFromConsole()
    .Throw(fail => throw new ApplicationException(fail.Error));

ConsoleHelper.Pause();

Console.WriteLine("Все данные:");
foreach (var each in viewer.Questionnaires)
{
    Console.WriteLine($"{each.Id.Id} - {each.Name.SurName} {each.Name.Name} {each.Age.Age} {each.Height.Height} {each.Weight.Weight}");
    Console.WriteLine(each.FormatText());
}


ConsoleHelper.PrintFooter();
