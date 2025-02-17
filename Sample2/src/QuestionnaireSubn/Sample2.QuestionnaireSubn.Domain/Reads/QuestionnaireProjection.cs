using Sample2.QuestionnaireSubn.Domain.QuestionnaireAggregate.Events;
using Sample2.QuestionnaireSubn.Domain.QuestionnaireAggregate.Values;
using System.Xml.Linq;

namespace Sample2.QuestionnaireSubn.Domain.Reads;

public record QuestionnaireProjection(QuestionnaireId Id, QuestionnaireName Name, AgeValue Age, HeightValue Height, WeightValue Weight)
{
    public string GluedLine => Name + " " + Age + " лет " + Height + " см " + Weight + " кг";

    public string Formatted => string.Format("{0} {1} лет {2} см {3} кг", Name, Age, Height, Weight);

    public string Interpolated => $"{Name} {Age} лет {Height} см {Weight} кг";

    public QuestionnaireProjection(QuestionnaireCreated ev) : this(ev.Id, ev.Name, ev.Age, ev.Height, ev.Weight)
    { }
}