using Microsoft.AspNetCore.Mvc;
using BlogApp.Data;
using BlogApp.Models;

namespace BlogApp.Controllers;

public class AccountController : Controller
{
    private readonly ApplicationDbContext _dbContext;

    public AccountController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        var user = _dbContext.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        if (user != null)
        {
            // Check if the user is approved
            if (!user.IsApproved)
            {
                ViewBag.Error = "Your account has not been approved by the admin.";
                return View();
            }

            // Store user info in session
            HttpContext.Session.SetString("Username", user.Username);
            HttpContext.Session.SetString("Role", user.Role);

            return RedirectToAction("Index", "Home");
        }
        else
        {
            ViewBag.Error = "Invalid username or password.";
            return View();
        }
    }

    [HttpGet]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login", "Account");
    }
}
