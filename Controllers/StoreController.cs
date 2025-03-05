using EugeneArtStore.Data;
using EugeneArtStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace EugeneArtStore.Controllers;

public class StoreController : Controller
{
    private readonly ApplicationDbContext _context;

    public StoreController(ApplicationDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        IEnumerable<Product> model = _context.Products.ToList();
        return View(model);
    }

    public IActionResult Details(int id)
    {
        Product model = _context.Products.Find(id);
        return View(model);
    }
}