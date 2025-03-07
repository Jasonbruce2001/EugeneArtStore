using EugeneArtStore.Models;

namespace EugeneArtStore.Data;

public interface IStoreRepository
{
    public List<Product> GetProducts();
    public List<Product> GetDescending();
    public List<Product> GetAscending();
    public Product GetProductById(int id);

    //asynchronous versions
    public Task<int> StoreProductAsync(Product model);  
    public int DeleteProduct(int id);

    
}