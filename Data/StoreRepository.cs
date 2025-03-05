using EugeneArtStore.Models;

namespace EugeneArtStore.Data;

public class StoreRepository : IStoreRepository
{
    public List<Product> GetProducts()
    {
        throw new NotImplementedException();
    }

    public Product GetProductById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<int> StoreProductAsync(Product model)
    {
        throw new NotImplementedException();
    }

    public int DeleteProduct(int id)
    {
        throw new NotImplementedException();
    }
}