using Easy.Questionnaire.Contract.EventSourcing.Abstractions;

namespace Easy.Questionnaire.Domain.Model.Values;

public record QuestionnaireId(Guid Id) : IIdentity
{
    public static QuestionnaireId New => new(Guid.NewGuid());
}