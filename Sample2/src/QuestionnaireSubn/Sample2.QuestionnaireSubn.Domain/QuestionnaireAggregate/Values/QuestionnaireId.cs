using Sample2.QuestionnaireSubn.Contract.EventSourcing.Abstractions;

namespace Sample2.QuestionnaireSubn.Domain.QuestionnaireAggregate.Values;

public record QuestionnaireId(Guid Id) : IIdentity;