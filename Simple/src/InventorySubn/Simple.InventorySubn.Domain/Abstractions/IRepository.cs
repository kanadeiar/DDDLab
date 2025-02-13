using Simple.InventorySubn.Domain.Base;

namespace Simple.InventorySubn.Domain.Abstractions;

public interface IRepository<out T> 
    where T : AggregateRoot, new()
{
    void Save(AggregateRoot aggregate, int expectedVersion);

    T GetById(Guid id);
}