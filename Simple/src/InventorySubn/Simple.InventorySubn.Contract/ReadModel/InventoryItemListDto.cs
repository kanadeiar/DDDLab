namespace Simple.InventorySubn.Contract.ReadModel;

public record InventoryItemListDto(Guid Id, string Name)
{
    public Guid Id { get; set; } = Id;
    public string Name { get; set; } = Name;
}