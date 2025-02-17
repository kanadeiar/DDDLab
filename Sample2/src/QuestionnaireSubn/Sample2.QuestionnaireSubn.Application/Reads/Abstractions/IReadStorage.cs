using Sample2.QuestionnaireSubn.Domain.Reads;

namespace Sample2.QuestionnaireSubn.Application.Reads.Abstractions;

public interface IReadStorage
{
    List<QuestionnaireProjection> All { get; }
}