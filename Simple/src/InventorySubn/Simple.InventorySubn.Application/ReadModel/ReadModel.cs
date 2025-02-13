using Simple.InventorySubn.Application.Abstractions;
using Simple.InventorySubn.Contract.ReadModel;
using Simple.InventorySubn.Contract.ReadModel.Abstractions;

namespace Simple.InventorySubn.Application.ReadModel;

public class ReadModel(IReadModelStorage database) : IReadModel
{
    public IEnumerable<InventoryItemListDto> GetInventoryItems()
    {
        return database.List;
    }

    public InventoryItemDetailsDto GetInventoryItemDetails(Guid id)
    {
        return database.Details[id];
    }
}