using Simple.InventorySubn.Application.Abstractions;
using Simple.InventorySubn.Domain.Abstractions;
using Simple.InventorySubn.Domain.ReadModel;

namespace Simple.InventorySubn.Application.ReadModel;

public class ReadModel(IReadModelStorage database) : IReadModel
{
    public IEnumerable<InventoryItemListProjection> GetInventoryItems()
    {
        return database.List;
    }

    public InventoryItemDetailsProjection GetInventoryItemDetails(Guid id)
    {
        return database.Details[id];
    }
}