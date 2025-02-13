namespace Simple.InventorySubn.Contract.ReadModel;

public struct InventoryItemDetailsDto(Guid id, string name, int maxQty, int currentCount, int version)
{
    public Guid Id { get; set; } = id;
    
    public string Name { get; set; } = name;

    public int MaxQty { get; set; } = maxQty;

    public int CurrentCount { get; set; } = currentCount;

    public int Version { get; set; } = version;
}