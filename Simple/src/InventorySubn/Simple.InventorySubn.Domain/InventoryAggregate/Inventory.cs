using Simple.InventorySubn.Contract.Base;
using Simple.InventorySubn.Domain.Base;
using Simple.InventorySubn.Domain.InventoryAggregate.Events;
using Simple.InventorySubn.Domain.InventoryAggregate.State;

namespace Simple.InventorySubn.Domain.InventoryAggregate;

public class Inventory : AggregateRoot
{
    public override Guid Id => _state.Id;

    private readonly InventoryState _state = new ();
    
    public Inventory(Guid id, string name)
    {
        ApplyChange(new InventoryItemCreated(id, name, _state.MaxQty));
    }
    public Inventory() { }

    public void ChangeName(string newName)
    {
        if (string.IsNullOrEmpty(newName)) throw new ArgumentException(nameof(newName));
        ApplyChange(new InventoryItemRenamed(Id, newName));
    }

    public void Remove(int count)
    {
        if (count <= 0) throw new InvalidOperationException("Нельзя удалить отрицательное количество элементов");
        if (_state.AvailableQty - count < 0) throw new InvalidOperationException("Нельзя удалить больше, чем доступно на этом месте");
        ApplyChange(new ItemsRemovedFromInventory(Id, count));
    }

    public void CheckIn(int count)
    {
        if (count <= 0) throw new InvalidOperationException("Нельзя добавить отрицательное количество элементов");
        if (_state.AvailableQty + count > _state.MaxQty) throw new InvalidOperationException("Количество превышает размер места");
        ApplyChange(new ItemsCheckedInToInventory(Id, count));
    }

    public void ChangeMaxQty(int newMaxQty)
    {
        if (newMaxQty <= 0) throw new InvalidOperationException("Новый размер места должен быть положительным числом");
        if (newMaxQty < _state.AvailableQty) throw new InvalidOperationException("Новый размер места не может быть меньше текущего количества");
        ApplyChange(new MaxQtyChanged(Id, newMaxQty));
    }

    public void Deactivate()
    {
        if (!_state.Activated) throw new InvalidOperationException("Место уже деактивировано");
        ApplyChange(new InventoryItemDeactivated(Id));
    }

    protected override void Apply(Event @event) => _state.Apply(@event);
}