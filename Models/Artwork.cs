namespace EugeneArtStore.Models;

public class Artwork
{
    public int Id { get; set; }
    public AppUser Author { get; set; }
    public string Link { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    
    public int Likes { get; set; }
    public DateOnly DatePosted { get; set; }
}