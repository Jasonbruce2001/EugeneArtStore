using EugeneArtStore.Models;

namespace EugeneArtStore.Data;

public class ArtworkRepository : IArtworkRepository
{
    private ApplicationDbContext _context;

    public ArtworkRepository(ApplicationDbContext c)
    {
        _context = c;
    }
    public List<Artwork> GetArtworks()
    {
        return _context.Artworks.ToList();
    }

    public Artwork GetArtworkById(int id)
    {
        return _context.Artworks.Find(id);
    }

    public int DeleteArtworkById(int id)
    {
        var artwork = _context.Artworks.Find(id);

        if (artwork != null)
        {
            _context.Artworks.Remove(artwork);
            _context.SaveChanges();
            
            return 1;
        }

        return 0;
    }

    public async Task<int> StoreArtworkAsync(Artwork model)
    {
        _context.Artworks.Add(model);
        
        Task<int> task = _context.SaveChangesAsync();
        int result = await task;
        return result; // returns a positive value if succussful
    }
}