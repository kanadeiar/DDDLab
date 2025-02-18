using Kanadeiar.Common;
using Sample2.QuestionnaireSubn.Contract.EventSourcing.Abstractions;

namespace Sample2.QuestionnaireSubn.Domain.QuestionnaireAggregate.Values;

public record QuestionnaireId(Guid Id) : IIdentity
{
    public static QuestionnaireId New => new(Guid.NewGuid());

    public Guid Id { get; } = Id.Require(Id != default, () =>
        throw new ApplicationException("Номер идентификатора должен быть положительным числом"));

    public override string ToString() => Id.ToString();
}