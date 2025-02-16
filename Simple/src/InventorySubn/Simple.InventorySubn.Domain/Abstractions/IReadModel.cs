using Simple.InventorySubn.Domain.ReadModel;

namespace Simple.InventorySubn.Domain.Abstractions;

public interface IReadModel
{
    IEnumerable<InventoryItemListProjection> GetInventoryItems();

    InventoryItemDetailsProjection GetInventoryItemDetails(Guid id);
}