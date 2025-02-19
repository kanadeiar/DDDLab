using Easy.Questionnaire.Contract.EventSourcing.Base;
using Easy.Questionnaire.Domain.Model.Values;

namespace Easy.Questionnaire.Domain.Model.Events;

public record QuestionnaireCreated(QuestionnaireId Id, QuestionnaireName Name, AgeValue Age, HeightValue Height, WeightValue Weight) : DomainEvent;