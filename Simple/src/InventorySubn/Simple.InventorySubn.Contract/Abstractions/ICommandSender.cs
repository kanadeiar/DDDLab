using Simple.InventorySubn.Contract.Base;

namespace Simple.InventorySubn.Domain.Abstractions;

public interface ICommandSender
{
    void Send<T>(T command) where T : Command;
}