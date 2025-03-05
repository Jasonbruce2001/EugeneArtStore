using EugeneArtStore.Models;

namespace EugeneArtStore.Data;

public interface IStoreRepository
{
    public List<Product> GetProducts();
    public Product GetProductById(int id);

    //asynchronous versions
    public Task<int> StoreProductAsync(Product model);  
    public int DeleteProduct(int id);
}