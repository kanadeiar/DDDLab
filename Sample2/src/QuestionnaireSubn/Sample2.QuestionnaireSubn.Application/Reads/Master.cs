using Sample2.QuestionnaireSubn.Application.Reads.Abstractions;
using Sample2.QuestionnaireSubn.Application.Reads.Views;
using Sample2.QuestionnaireSubn.Contract.EventSourcing.Abstractions;
using Sample2.QuestionnaireSubn.Domain.QuestionnaireAggregate.Events;
using Sample2.QuestionnaireSubn.Domain.Reads;

namespace Sample2.QuestionnaireSubn.Application.Reads;

public class Master(IReadStorage storage, IDispatcher dispatcher)
{
    private QuestionnaireView _view = new(storage);

    public IEnumerable<QuestionnaireProjection> Questionnaires => storage.All;

    public void Start()
    {
        dispatcher.RegisterHandler<QuestionnaireCreated>(_view.Handle);
    }
}