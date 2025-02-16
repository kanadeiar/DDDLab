using Simple.InventorySubn.Application.Abstractions;
using Simple.InventorySubn.Domain.ReadModel;

namespace Simple.InventorySubn.Infra.Data;

public class ReadModelStorage : IReadModelStorage
{
    public Dictionary<Guid, InventoryItemDetailsProjection> Details { get; } = new();

    public List<InventoryItemListProjection> List { get; } = new();
}