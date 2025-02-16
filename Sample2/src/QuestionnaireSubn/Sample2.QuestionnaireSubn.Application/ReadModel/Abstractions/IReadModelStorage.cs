using Sample2.QuestionnaireSubn.Domain.ReadModel;

namespace Sample2.QuestionnaireSubn.Application.ReadModel.Abstractions;

public interface IReadModelStorage
{
    List<QuestionnaireProjection> All { get; }
}