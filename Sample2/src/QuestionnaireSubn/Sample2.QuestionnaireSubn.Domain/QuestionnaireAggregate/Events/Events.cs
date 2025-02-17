using Sample2.QuestionnaireSubn.Contract.EventSourcing.Base;
using Sample2.QuestionnaireSubn.Domain.QuestionnaireAggregate.Values;

namespace Sample2.QuestionnaireSubn.Domain.QuestionnaireAggregate.Events;

public record QuestionnaireCreated(QuestionnaireId Id, QuestionnaireName Name, AgeValue Age, HeightValue Height, WeightValue Weight) : DomainEvent;
