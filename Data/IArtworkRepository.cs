using EugeneArtStore.Models;

namespace EugeneArtStore.Data;

public interface IArtworkRepository
{
    public List<Artwork> GetArtworks();
    public Artwork GetArtworkById(int id);
    public int DeleteArtworkById(int id);

    //asynchronous versions
    public Task<int> StoreArtworkAsync(Artwork model);  
}