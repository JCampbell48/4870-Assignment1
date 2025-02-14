using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers;

public class ContributorController : Controller
{
    [HttpGet]
    public IActionResult ContributorDashboard()
    {
        if (HttpContext.Session.GetString("Role") != "Contributor")
        {
            return Unauthorized(); // Redirect to login page
        }

        return View();
    }
}
