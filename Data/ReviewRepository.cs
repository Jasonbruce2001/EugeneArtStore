using EugeneArtStore.Models;
using Microsoft.EntityFrameworkCore;

namespace EugeneArtStore.Data;

public class ReviewRepository : IReviewRepository
{
    private readonly ApplicationDbContext _context;

    public ReviewRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public List<Review> GetReviews()
    {
        return _context.Reviews
                        .Include(review => review.Author)
                        .ToList();
    }

    public Review GetReviewById(int id)
    {
        var review = _context.Reviews.Find(id);
        if (review != null)
        {
            return review;
        }
        else
        {
            throw new KeyNotFoundException("No Review found");
        }
    }

    public List<Review> GetProductReviews(int id)
    {
        return _context.Reviews.Where(review => review.ProductId == id)
                                .Include(review => review.Author)
                                .ToList();
    }

    public async Task<int> StoreReviewAsync(Review model)
    {
        _context.Reviews.Add(model);

        return await _context.SaveChangesAsync();
    }

    public int DeleteReview(int id)
    {
        var review = _context.Reviews.Find(id);

        if (review != null)
        {
            _context.Reviews.Remove(review);
            _context.SaveChanges();
            
            return 1;
        }

        return 0;
    }
}