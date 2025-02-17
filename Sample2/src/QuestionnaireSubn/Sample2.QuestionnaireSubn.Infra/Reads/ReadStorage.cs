using Sample2.QuestionnaireSubn.Application.Reads.Abstractions;
using Sample2.QuestionnaireSubn.Domain.Reads;

namespace Sample2.QuestionnaireSubn.Infra.Reads;

public class ReadStorage : IReadStorage
{
    public List<QuestionnaireProjection> All { get; } = new();
}