namespace Simple.InventorySubn.Contract.ReadModel;

public struct InventoryItemListDto(Guid id, string name)
{
    public Guid Id { get; set; } = id;
    public string Name { get; set; } = name;
}