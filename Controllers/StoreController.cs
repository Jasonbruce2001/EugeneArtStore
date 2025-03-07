using EugeneArtStore.Data;
using EugeneArtStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EugeneArtStore.Controllers;

public class StoreController : Controller
{
    private readonly IStoreRepository _repository;
    private readonly IReviewRepository _reviewRepository;
    private UserManager<AppUser> _userManager; 

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

    public IActionResult ReviewForm(int id)
    {
        ViewData["ProductId"] = id;
        
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> ReviewForm(Review model)
    {
        model.Author = await _userManager.GetUserAsync(User);
        
        if (_reviewRepository.StoreReviewAsync(model).Result > 0)
        {
            return View("Index", _repository.GetProducts());
        }
        else
        {
            ViewBag.ErrorMessage = "There was an error saving the story.";
            return View("Index", _repository.GetProducts());
        }
    }
    
}