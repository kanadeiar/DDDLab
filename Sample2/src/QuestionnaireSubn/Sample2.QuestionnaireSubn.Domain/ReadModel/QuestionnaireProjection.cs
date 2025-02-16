using Sample2.QuestionnaireSubn.Domain.QuestionnaireAggregate.Events;
using Sample2.QuestionnaireSubn.Domain.QuestionnaireAggregate.Values;

namespace Sample2.QuestionnaireSubn.Domain.ReadModel;

public record QuestionnaireProjection(QuestionnaireId Id, QuestionnaireName Name, AgeValue Age, HeightValue Height, WeightValue Weight)
{
    public QuestionnaireProjection(QuestionnaireCreated ev) : this(ev.Id, ev.Name, ev.Age, ev.Height, ev.Weight)
    { }

    public string FormatText()
    {
        return $"{Name.SurName} {Name.Name} {Age.Age} лет {Height.Height} см {Weight.Weight} кг";
    }
}