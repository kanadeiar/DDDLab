using SimpleCQRS.InventorySub.Domain.Base;

namespace SimpleCQRS.InventorySub.Domain.Abstractions;

public interface IRepository<out T> 
    where T : AggregateRoot, new()
{
    void Save(AggregateRoot aggregate, int expectedVersion);

    T GetById(Guid id);
}