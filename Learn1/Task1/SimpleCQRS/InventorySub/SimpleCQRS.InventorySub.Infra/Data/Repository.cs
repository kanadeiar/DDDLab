using SimpleCQRS.InventorySub.Domain.Abstractions;
using SimpleCQRS.InventorySub.Domain.Base;

namespace SimpleCQRS.InventorySub.Infra.Data;

public class Repository<T>(IEventStore storage) : IRepository<T>
    where T : AggregateRoot, new()
{
    public void Save(AggregateRoot aggregate, int expectedVersion)
    {
        storage.SaveEvents(aggregate.Id, aggregate.GetChanges(), expectedVersion);
    }

    public T GetById(Guid id)
    {
        var result = new T();
        var e = storage.GetEventsForAggregate(id);
        result.LoadsFromHistory(e);
        return result;
    }
}