using EugeneArtStore.Models;

namespace EugeneArtStore.Data;

public interface ICommentRepository
{
    public List<Comment> GetComments();
    public Comment GetCommentById(int id);
    public List<Comment> GetArtworkComments(int id);

    //asynchronous versions
    public Task<int> StoreCommentAsync(Comment model);  
    public int DeleteComment(int id);
}