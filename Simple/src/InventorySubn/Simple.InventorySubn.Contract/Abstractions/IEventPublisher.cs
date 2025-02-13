using Simple.InventorySubn.Contract.Base;

namespace Simple.InventorySubn.Domain.Abstractions;

public interface IEventPublisher
{
    void Publish<T>(T @event) where T : Event;
}