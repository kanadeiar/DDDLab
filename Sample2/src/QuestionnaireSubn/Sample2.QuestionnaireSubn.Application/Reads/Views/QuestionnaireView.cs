using Sample2.QuestionnaireSubn.Application.Reads.Abstractions;
using Sample2.QuestionnaireSubn.Domain.QuestionnaireAggregate.Events;
using Sample2.QuestionnaireSubn.Domain.Reads;

namespace Sample2.QuestionnaireSubn.Application.Reads.Views;

public class QuestionnaireView(IReadStorage storage)
{
    public void Handle(QuestionnaireCreated message)
    {
        storage.All.Add(new QuestionnaireProjection(message));
    }
}