using Easy.Questionnaire.Domain.Model.Events;
using Easy.Questionnaire.Domain.Model.Values;

namespace Easy.Questionnaire.Domain.ReadModel;

public record QuestionnaireProjection(QuestionnaireId Id, QuestionnaireName Name, AgeValue Age, HeightValue Height, WeightValue Weight)
{
    public QuestionnaireProjection(QuestionnaireCreated ev) : this(ev.Id, ev.Name, ev.Age, ev.Height, ev.Weight)
    { }
}