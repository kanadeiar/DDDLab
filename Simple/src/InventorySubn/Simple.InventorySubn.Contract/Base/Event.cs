using Simple.InventorySubn.Contract.Abstractions;

namespace Simple.InventorySubn.Contract.Base;

public record Event : IMessage
{
    public int Version;
}