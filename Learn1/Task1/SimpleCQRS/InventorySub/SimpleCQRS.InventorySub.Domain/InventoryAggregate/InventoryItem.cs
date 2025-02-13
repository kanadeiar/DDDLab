using SimpleCQRS.InventorySub.Domain.Base;
using SimpleCQRS.InventorySub.Domain.Events;

namespace SimpleCQRS.InventorySub.Domain.InventoryAggregate;

public class InventoryItem : AggregateRoot
{
    private readonly InventoryState _state = new ();

    public override Guid Id => _state.Id;
    
    public InventoryItem(Guid id, string name)
    {
        ApplyChange(new InventoryItemCreated(id, name, _state.MaxQty));
    }

    public void ChangeName(string newName)
    {
        if (string.IsNullOrEmpty(newName)) throw new ArgumentException("newName");
        ApplyChange(new InventoryItemRenamed(Id, newName));
    }

    public void Remove(int count)
    {
        if (count <= 0) throw new InvalidOperationException("cant remove negative count from inventory");
        if (_state.AvailableQty - count < 0) throw new InvalidOperationException("Cannot remove a count greater than the available quantity");
        ApplyChange(new ItemsRemovedFromInventory(Id, count));
    }

    public void CheckIn(int count)
    {
        if (count <= 0) throw new InvalidOperationException("must have a count greater than 0 to add to inventory");
        if (_state.AvailableQty + count > _state.MaxQty) throw new InvalidOperationException("Checked in count will exceed Max Qty");
        ApplyChange(new ItemsCheckedInToInventory(Id, count));
    }

    public void ChangeMaxQty(int newMaxQty)
    {
        if (newMaxQty <= 0) throw new InvalidOperationException("New Max Qty must be larger than 0");
        if (newMaxQty < _state.AvailableQty) throw new InvalidOperationException("New Max Qty cannot be less than Available Qty");
        ApplyChange(new MaxQtyChanged(Id, newMaxQty));
    }

    public void Deactivate()
    {
        if (!_state.Activated) throw new InvalidOperationException("already deactivated");
        ApplyChange(new InventoryItemDeactivated(Id));
    }

    protected override void ApplyChange(Event @event, bool isNew)
    {
        _state.ApplyChange(@event);
        if (isNew) Changes.Add(@event);
    }
}