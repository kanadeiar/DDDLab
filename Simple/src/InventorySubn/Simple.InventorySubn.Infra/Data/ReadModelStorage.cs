using Simple.InventorySubn.Application.Abstractions;
using Simple.InventorySubn.Contract.ReadModel;

namespace Simple.InventorySubn.Infra.Data;

public class ReadModelStorage : IReadModelStorage
{
    public Dictionary<Guid, InventoryItemDetailsDto> Details { get; } = new();

    public List<InventoryItemListDto> List { get; } = new();
}