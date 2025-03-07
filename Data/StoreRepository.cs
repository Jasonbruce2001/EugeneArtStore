using EugeneArtStore.Models;

namespace EugeneArtStore.Data;

public class StoreRepository : IStoreRepository
{
    private readonly ApplicationDbContext _context;

    public StoreRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public List<Product> GetProducts()
    {
        return _context.Products.ToList();
    }

    public List<Product> GetDescending()
    {
        return _context.Products.OrderByDescending(p => p.Price).ToList();
    }

    public List<Product> GetAscending()
    {
        return _context.Products.OrderBy(p => p.Price).ToList();
    }

    public Product GetProductById(int id)
    {
        return _context.Products.Find(id);
    }

    public async Task<int> StoreProductAsync(Product model)
    {
        _context.Products.Add(model);
        
        Task<int> task = _context.SaveChangesAsync();
        int result = await task;
        return result; // returns a positive value if succussful
    }

    public int DeleteProduct(int id)
    {
        var product = _context.Products.Find(id);

        if (product != null)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
            
            return 1;
        }

        return 0;
    }
}