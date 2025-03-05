using Microsoft.AspNetCore.Mvc;

namespace EugeneArtStore.Controllers;

public class StoreController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}