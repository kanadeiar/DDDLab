using Simple.InventorySubn.Domain.ReadModel;

namespace Simple.InventorySubn.Application.Abstractions;

public interface IReadModelStorage
{
    Dictionary<Guid, InventoryItemDetailsProjection> Details { get; }

    List<InventoryItemListProjection> List { get; }
}