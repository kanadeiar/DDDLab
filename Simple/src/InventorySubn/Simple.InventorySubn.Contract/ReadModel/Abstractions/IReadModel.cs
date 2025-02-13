namespace Simple.InventorySubn.Contract.ReadModel.Abstractions;

public interface IReadModel
{
    IEnumerable<InventoryItemListDto> GetInventoryItems();

    InventoryItemDetailsDto GetInventoryItemDetails(Guid id);
}