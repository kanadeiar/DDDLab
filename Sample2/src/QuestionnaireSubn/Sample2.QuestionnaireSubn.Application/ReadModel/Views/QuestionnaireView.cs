using Sample2.QuestionnaireSubn.Application.ReadModel.Abstractions;
using Sample2.QuestionnaireSubn.Domain.QuestionnaireAggregate.Events;
using Sample2.QuestionnaireSubn.Domain.ReadModel;

namespace Sample2.QuestionnaireSubn.Application.ReadModel.Views;

public class QuestionnaireView(IReadModelStorage storage)
{
    public void Handle(QuestionnaireCreated message)
    {
        storage.All.Add(new QuestionnaireProjection(message));
    }
}