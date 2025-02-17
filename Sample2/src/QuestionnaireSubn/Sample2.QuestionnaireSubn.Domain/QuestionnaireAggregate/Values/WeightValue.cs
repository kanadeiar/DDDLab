using Kanadeiar.Common;

namespace Sample2.QuestionnaireSubn.Domain.QuestionnaireAggregate.Values;

public record WeightValue(int Weight)
{
    public int Weight { get; } = Weight.Require(Weight is > 50 and < 200, () =>
        throw new ApplicationException("Вес должен быть от 10 до 200 кг"));

    public override string ToString() => Weight.ToString();
}