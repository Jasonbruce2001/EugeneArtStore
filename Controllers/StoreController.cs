using EugeneArtStore.Data;
using EugeneArtStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EugeneArtStore.Controllers;

public class StoreController : Controller
{
    private readonly IStoreRepository _repository;
    private readonly IReviewRepository _reviewRepository;
    private readonly UserManager<AppUser> _userManager; 

    public StoreController(IStoreRepository repo, IReviewRepository reviewRepo, UserManager<AppUser> userManager)
    {
        _repository = repo;
        _reviewRepository = reviewRepo;
        _userManager = userManager;
    }
    public IActionResult Index()
    {
        IEnumerable<Product> model = _repository.GetProducts();
        return View(model);
    }

    public IActionResult Details(int id)
    {
        ViewData["Reviews"] = _reviewRepository.GetProductReviews(id);
        
        var model = _repository.GetProductById(id);
        
        return View(model);
    }

    public IActionResult Descending()
    {
        IEnumerable<Product> model = _repository.GetDescending();
        return View("Index", model);
    }
    
    public IActionResult Ascending()
    {
        IEnumerable<Product> model = _repository.GetAscending();
        return View("Index", model);
    }

    public IActionResult Filter(string search)
    {
        IEnumerable<Product> model;

        if (string.IsNullOrEmpty(search))
        {
            model = _repository.GetProducts().ToList();
        }
        else
        {
            model = _repository.GetProducts()
                .Where(p => p.Name.ToLower().Contains(search.ToLower()))
                .ToList();
        }
        
        return View("Index", model);
    }

    public IActionResult ReviewForm(int productId)
    {
        ViewData["ProductId"] = productId;
        
        return View();
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> ReviewForm(Review model)
    {
        model.Author = await _userManager.GetUserAsync(User);
        model.DateCreated = DateTime.Now;
        
        await _reviewRepository.StoreReviewAsync(model);
        
        var product = _repository.GetProductById(model.ProductId);
        ViewData["Reviews"] = _reviewRepository.GetProductReviews(model.ProductId);
        
        return View("Details", product);
    }
    
}