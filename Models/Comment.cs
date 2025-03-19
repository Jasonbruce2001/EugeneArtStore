namespace EugeneArtStore.Models;

public class Comment
{
    public int Id { get; set; }
    public int ArtworkId { get; set; }
    public AppUser Author { get; set; }
    public string Content { get; set; }
    public DateTime DateCreated { get; set; }
}
