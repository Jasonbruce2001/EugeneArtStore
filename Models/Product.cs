namespace EugeneArtStore.Models;

public class Product
{
    public int Id { get; set; }
    public Decimal Price  { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string? PhotoUrl { get; set; }
    public bool InStock { get; set; }
}