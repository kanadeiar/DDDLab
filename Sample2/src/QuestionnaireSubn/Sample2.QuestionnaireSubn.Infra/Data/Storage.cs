using Sample2.QuestionnaireSubn.Contract.EventSourcing;
using Sample2.QuestionnaireSubn.Contract.EventSourcing.Abstractions;

namespace Sample2.QuestionnaireSubn.Infra.Data;

public class Storage<T>(IEventStore storage) : IStorage<T>
    where T : AggregateRoot, new()
{
    public T GetById(IIdentity id)
    {
        var result = new T();
        var stream = storage.LoadEventStream(id);
        result.LoadsFromHistory(stream.Events);
        return result;
    }

    public void Save(AggregateRoot aggregate, int expectedVersion)
    {
        storage.AppendToStream(aggregate.Id, aggregate.Changes(), expectedVersion);
    }
}