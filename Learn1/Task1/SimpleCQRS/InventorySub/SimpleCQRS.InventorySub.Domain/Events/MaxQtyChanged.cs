using SimpleCQRS.InventorySub.Domain.Base;

namespace SimpleCQRS.InventorySub.Domain.Events;

public record MaxQtyChanged(Guid Id, int NewMaxQty) : Event
{

}