using Simple.InventorySubn.Contract.ReadModel;

namespace Simple.InventorySubn.Application.Abstractions;

public interface IReadModelStorage
{
    Dictionary<Guid, InventoryItemDetailsDto> Details { get; }

    List<InventoryItemListDto> List { get; }
}