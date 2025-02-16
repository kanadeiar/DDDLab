using Sample2.QuestionnaireSubn.Contract.EventSourcing.Abstractions;
using Sample2.QuestionnaireSubn.Domain.QuestionnaireAggregate.Events;

namespace Sample2App;

public static class DeveloperScript
{
    public static void CreateTestSubscribe(IDispatcher dispatcher)
    {
        dispatcher.RegisterHandler<QuestionnaireCreated>(ev =>
        {
            Console.WriteLine("## Событие - создана новая анкета ##" + ev.Id + " " + ev.Name.SurName + " " + ev.Name.Name);
        });
    }
}