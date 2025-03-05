namespace EugeneArtStore.Models;

public class Review
{
    public int Id { get; set; }
    public AppUser Author { get; set; }
    public string Content { get; set; }
    public int Rating { get; set; }
    public int Helpful { get; set; } //number of times other users found this review helpful
    public DateTime DateCreated { get; set; }
}