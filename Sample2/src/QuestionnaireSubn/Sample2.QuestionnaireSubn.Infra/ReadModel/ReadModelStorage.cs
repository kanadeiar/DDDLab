using Sample2.QuestionnaireSubn.Application.ReadModel.Abstractions;
using Sample2.QuestionnaireSubn.Domain.ReadModel;

namespace Sample2.QuestionnaireSubn.Infra.ReadModel;

public class ReadModelStorage : IReadModelStorage
{
    public List<QuestionnaireProjection> All { get; } = new();
}