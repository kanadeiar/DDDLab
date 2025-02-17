using Kanadeiar.Common;

namespace Sample2.QuestionnaireSubn.Domain.QuestionnaireAggregate.Values;

public record HeightValue(int Height)
{
    public int Height { get; } = Height.Require(Height is > 50 and < 200, () =>
        throw new ApplicationException("Рост должнен быть от 50 до 200 см"));

    public override string ToString() => Height.ToString();
}