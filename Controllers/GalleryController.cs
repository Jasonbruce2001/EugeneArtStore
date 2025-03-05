using EugeneArtStore.Data;
using EugeneArtStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace EugeneArtStore.Controllers;

public class GalleryController : Controller
{
    private IArtworkRepository _artRepo;

    public GalleryController(IArtworkRepository artRepo)
    {
        _artRepo = artRepo;
    }
    
    // GET
    public IActionResult Art()
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

    [HttpPost]
    public IActionResult Delete(int id)
    {
        int result = _artRepo.DeleteArtworkById(id);
        List<Artwork> artworks = _artRepo.GetArtworks();
        
        return View("Edit", artworks);
    }
}