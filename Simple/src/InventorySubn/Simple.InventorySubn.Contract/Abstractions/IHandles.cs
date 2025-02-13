namespace Simple.InventorySubn.Domain.Abstractions;

public interface IHandles<in T>
{
    void Handle(T message);
}