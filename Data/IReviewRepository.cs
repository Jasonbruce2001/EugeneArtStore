using EugeneArtStore.Models;

namespace EugeneArtStore.Data;

public interface IReviewRepository
{
    public List<Review> GetReviews();
    public Review GetReviewById(int id);
    public List<Review> GetProductReviews(int id);

    //asynchronous versions
    public Task<int> StoreReviewAsync(Review model);  
    public int DeleteReview(int id);
}