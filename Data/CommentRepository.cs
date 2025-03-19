using EugeneArtStore.Models;
using Microsoft.EntityFrameworkCore;

namespace EugeneArtStore.Data;

public class CommentRepository : ICommentRepository
{
    private readonly ApplicationDbContext _context;

    public CommentRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public List<Comment> GetComments()
    {
        return _context.Comments
                        .Include(c => c.Author)
                        .ToList();
    }

    public Comment GetCommentById(int id)
    {
        var comment = _context.Comments.Find(id);
        if (comment != null)
        {
            return comment;
        }
        else
        {
            throw new KeyNotFoundException("No Comment found");
        }
    }

    public List<Comment> GetArtworkComments(int id)
    {
        return _context.Comments.Where(c => c.ArtworkId == id)
                                .Include(c => c.Author)
                                .ToList();
    }

    public async Task<int> StoreCommentAsync(Comment model)
    {
        _context.Comments.Add(model);

        return await _context.SaveChangesAsync();
    }

    public int DeleteComment(int id)
    {
        var comment = _context.Comments.Find(id);

        if (comment != null)
        {
            _context.Comments.Remove(comment);
            _context.SaveChanges();
            
            return 1;
        }

        return 0;
    }
}