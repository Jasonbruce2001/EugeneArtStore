using EugeneArtStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EugeneArtStore.Controllers;

public class RegisterVmController : Controller
{
    private UserManager<AppUser> _userManager; 
    private SignInManager<AppUser> _signInManager;
    public RegisterVmController(UserManager<AppUser> userMngr, SignInManager<AppUser> signInMngr)
    {
        _userManager = userMngr; _signInManager = signInMngr;
    } 
    
    // GET
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterVm model)
    {
        if (ModelState.IsValid)
        {
            DateOnly date = DateOnly.FromDateTime(DateTime.Now);
            var user = new AppUser() { UserName = model.Username, AccountAge = date};
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
        }
        
        return View(model);
    }
    
    [HttpGet]
    public IActionResult LogIn(string returnURL = "")
    {
        var model = new LogInVm { ReturnUrl = returnURL };
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> LogIn(LogInVm model)
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync
                (model.Username, model.Password, model.RememberMe, false);
            if (result.Succeeded)
            {
                if (!string.IsNullOrEmpty(model.ReturnUrl) &&
                    Url.IsLocalUrl(model.ReturnUrl))
                {
                    return Redirect(model.ReturnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
        }

        ModelState.AddModelError(string.Empty, "Invalid username or password.");
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> LogOut()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}