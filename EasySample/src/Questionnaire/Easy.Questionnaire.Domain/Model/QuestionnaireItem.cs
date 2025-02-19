using Easy.Questionnaire.Contract.EventSourcing;
using Easy.Questionnaire.Contract.EventSourcing.Base;
using Easy.Questionnaire.Domain.Model.Events;
using Easy.Questionnaire.Domain.Model.Values;

namespace Easy.Questionnaire.Domain.Model;

public class QuestionnaireItem : AggregateRoot
{
    private QuestionnaireId _id = default!;
    public override QuestionnaireId AggregateId => _id;

    public QuestionnaireItem(QuestionnaireId id, QuestionnaireName name, AgeValue age, HeightValue height, WeightValue weight)
    {
        ApplyChange(new QuestionnaireCreated(id, name, age, height, weight));
    }

    public QuestionnaireItem()
    { }

    protected override void Mutate(DomainEvent @event) => 
        ((dynamic)this).when((dynamic)@event);

    private void when(QuestionnaireCreated ev)
    {
        _id = ev.Id;
    }
}