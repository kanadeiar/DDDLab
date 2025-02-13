using Simple.InventorySubn.Contract.Abstractions;
using Simple.InventorySubn.Domain.Abstractions;
using Simple.InventorySubn.Domain.Base;

namespace Simple.InventorySubn.Infra.Data;

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
        var events = storage.GetEventsForAggregate(id);
        result.LoadsFromHistory(events);
        return result;
    }
}