namespace Simple.InventorySubn.Contract.ReadModel;

public record InventoryItemDetailsDto(Guid Id, string Name, int MaxQty, int CurrentCount, int Version)
{
    public Guid Id { get; set; } = Id;
    
    public string Name { get; set; } = Name;

    public int MaxQty { get; set; } = MaxQty;

    public int CurrentCount { get; set; } = CurrentCount;

    public int Version { get; set; } = Version;
}