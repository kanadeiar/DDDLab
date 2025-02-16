using Sample2.QuestionnaireSubn.Application.ReadModel.Abstractions;
using Sample2.QuestionnaireSubn.Application.ReadModel.Views;
using Sample2.QuestionnaireSubn.Contract.EventSourcing.Abstractions;
using Sample2.QuestionnaireSubn.Domain.QuestionnaireAggregate.Events;
using Sample2.QuestionnaireSubn.Domain.ReadModel;

namespace Sample2.QuestionnaireSubn.Application.ReadModel;

public class Viewer(IReadModelStorage storage, IDispatcher dispatcher)
{
    private QuestionnaireView _view = new(storage);

    public IEnumerable<QuestionnaireProjection> Questionnaires => storage.All;

    public void Init()
    {
        dispatcher.RegisterHandler<QuestionnaireCreated>(_view.Handle);
    }
}