using EugeneArtStore.Data;
using EugeneArtStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EugeneArtStore.Controllers;

public class GalleryController : Controller
{
    private readonly IArtworkRepository _artRepo;
    private readonly ICommentRepository _commentRepo;
    private readonly UserManager<AppUser> _userManager; 

    public GalleryController(IArtworkRepository artRepo, ICommentRepository commentRepo, UserManager<AppUser> userManager)
    {
        _artRepo = artRepo;
        _userManager = userManager;
        _commentRepo = commentRepo;
    }
    
    // GET
    public IActionResult Index()
    {
        List<Artwork> artworks = _artRepo.GetArtworks();
        
        return View(artworks);
    }

    public IActionResult Edit()
    {
        List<Artwork> artworks = _artRepo.GetArtworks();
        
        return View(artworks);
    }

    public IActionResult Add()
    {
        return View();
    }
    
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Add(Artwork model)
    {
        model.Author = _userManager.GetUserAsync(User).Result;
        model.DatePosted = DateOnly.FromDateTime(DateTime.Now);
        await _artRepo.StoreArtworkAsync(model);
        
        return View("Index", _artRepo.GetArtworks());
    }

    public IActionResult DetailedGallery(int id)
    {
        var model = _artRepo.GetArtworkById(id);
        ViewData["Comments"] = _commentRepo.GetArtworkComments(id);
        
        return View(model);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> DetailedGallery(Comment model)
    {
        model.Author = await _userManager.GetUserAsync(User);
        model.DateCreated = DateTime.Now;
        await _commentRepo.StoreCommentAsync(model);
        
        return RedirectToAction("DetailedGallery");
    }

    [Authorize]
    [HttpPost]
    public IActionResult Delete(int id)
    {
        int result = _artRepo.DeleteArtworkById(id);
        List<Artwork> artworks = _artRepo.GetArtworks();
        
        return View("Edit", artworks);
    }

    public IActionResult LikePost()
    {
        return View("DetailedGallery");
    }
}