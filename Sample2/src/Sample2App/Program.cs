using Kanadeiar.Common;
using Sample2.QuestionnaireSubn.Application.QuestionnaireFunction;
using Sample2.QuestionnaireSubn.Application.Reads;
using Sample2.QuestionnaireSubn.Domain.QuestionnaireAggregate;
using Sample2.QuestionnaireSubn.Infra.Data;
using Sample2.QuestionnaireSubn.Infra.Reads;
using Sample2.QuestionnaireSubn.Infra.Tools;

ConsoleHelper.PrintHeader("Опытно-экспериментальное приложение.", "Опыты с DDD.");
ConsoleHelper.PrintLine("Наработка практического опыта CQRS + ES");

var dispatcher = new DomainEventDispatcher();
dispatcher.Run();
var store = new EventStore(dispatcher);
var storage = new Storage<Questionnaire>(store);

var readStorage = new ReadStorage();
var viewer = new Viewer(readStorage, dispatcher);
viewer.Init();

var service = new QuestionnaireApplicationService(storage);

service.CreateQuestionnaireFromConsole()
    .Throw(fail => throw new ApplicationException(fail.Error));

ConsoleHelper.Pause();

ConsoleHelper.PrintLine("Все данные:");
foreach (var each in viewer.Questionnaires)
{
    ConsoleHelper.PrintValueWithMessage("Склеивание", each.GluedLine);
    ConsoleHelper.PrintValueWithMessage("Форматирование", each.Formatted);
    ConsoleHelper.PrintValueWithMessage("Интерполяция", each.Interpolated);
}

ConsoleHelper.PrintFooter();
