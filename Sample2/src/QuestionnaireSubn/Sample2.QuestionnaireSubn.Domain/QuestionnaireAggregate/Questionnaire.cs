using Sample2.QuestionnaireSubn.Contract.EventSourcing;
using Sample2.QuestionnaireSubn.Contract.EventSourcing.Base;
using Sample2.QuestionnaireSubn.Domain.QuestionnaireAggregate.Values;
using Sample2.QuestionnaireSubn.Domain.QuestionnaireAggregate.Events;

namespace Sample2.QuestionnaireSubn.Domain.QuestionnaireAggregate;

public class Questionnaire : AggregateRoot
{
    private QuestionnaireId _id;
    private bool _activated;
    
    public override QuestionnaireId Id => _id;

    //public QuestionnaireName Name { get; private set; }

    //public AgeValue Age { get; private set; }
    
    //public HeightValue Height { get; private set; }

    //public WeightValue Weight { get; private set; }

    public Questionnaire(QuestionnaireId id, QuestionnaireName name, AgeValue age, HeightValue height, WeightValue weight)
    {
        ApplyChange(new QuestionnaireCreated(id, name, age, height, weight));
    }

    public Questionnaire()
    { }

    //public void Deactivate()
    //{
    //    if (!_activated) throw new InvalidOperationException("Анкета уже деактивирована");
    //    ApplyChange(new QuestionnaireDeactivated(Id));
    //}

    //public void ChangeAge(AgeValue newAge)
    //{
    //    if (Math.Abs(newAge.Age - Age.Age) > 1) throw new InvalidOperationException("Нельзя изменить возраст более чем на 1 год");
    //    ApplyChange(new QuestionnaireAgeChanges(Id, newAge));
    //}

    protected override void Mutate(DomainEvent ev)
    {
        ((dynamic)this).when((dynamic)ev);
    }

    private void when(QuestionnaireCreated ev)
    {
        _id = ev.Id;
        _activated = true;
        //Name = ev.Name;
        //Age = ev.Age;
        //Height = ev.Height;
        //Weight = ev.Weight;
    }
}