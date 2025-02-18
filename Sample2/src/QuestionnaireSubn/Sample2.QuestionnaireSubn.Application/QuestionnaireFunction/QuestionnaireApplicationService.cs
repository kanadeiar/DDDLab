using Kanadeiar.Common;
using Sample2.QuestionnaireSubn.Contract.EventSourcing.Abstractions;
using Sample2.QuestionnaireSubn.Domain.QuestionnaireAggregate;
using Sample2.QuestionnaireSubn.Domain.QuestionnaireAggregate.Values;

namespace Sample2.QuestionnaireSubn.Application.QuestionnaireFunction;

public class QuestionnaireApplicationService(IStorage<Questionnaire> storage)
{
    public Result CreateQuestionnaireFromConsole()
    {
        try
        {
            var surName = ConsoleHelper.ReadLineFromConsole("Введите фамилию")!;
            var name = ConsoleHelper.ReadLineFromConsole("Введите имя")!;
            var age = ConsoleHelper.ReadNumberFromConsole<int>("Введите возраст");
            var height = ConsoleHelper.ReadNumberFromConsole<int>("Введите рост");
            var weight = ConsoleHelper.ReadNumberFromConsole<int>("Введите вес");

            var questionnaire = new Questionnaire(new QuestionnaireName(surName, name), new AgeValue(age), new HeightValue(height),
                new WeightValue(weight));

            storage.Save(questionnaire, -1);

            return Result.Ok();
        }
        catch (Exception e)
        {
            return Result.Fail("Не удалось получить анкету с консоли. Ошибка: " + e);
        }
    }
}