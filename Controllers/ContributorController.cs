using Microsoft.AspNetCore.Mvc;
using BlogApp.Data;
using BlogApp.Models;

namespace BlogApp.Controllers;

public class ContributorController : Controller
{
    private readonly ApplicationDbContext _dbContext;

    public ContributorController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public IActionResult ContributorDashboard()
    {
        if (HttpContext.Session.GetString("Role") != "Contributor")
        {
            return Unauthorized(); // Redirect to login page or show error
        }

        // Fetch articles created by the logged-in contributor
        var username = HttpContext.Session.GetString("Username");
        var articles = _dbContext.Articles.Where(a => a.ContributorUsername == username).ToList();

        return View(articles); // Pass articles to the view
    }

    [HttpGet]
    public IActionResult CreateArticle()
    {
        if (HttpContext.Session.GetString("Role") != "Contributor")
        {
            return Unauthorized();
        }

        return View();
    }

    [HttpPost]
    public IActionResult CreateArticle(Article article)
    {
        if (HttpContext.Session.GetString("Role") != "Contributor")
        {
            return Unauthorized();
        }

        if (ModelState.IsValid)
        {
            article.ContributorUsername = HttpContext.Session.GetString("Username");
            article.CreateDate = DateTime.UtcNow;

            _dbContext.Articles.Add(article);
            _dbContext.SaveChanges();

            return RedirectToAction("ContributorDashboard");
        }

        return View(article);
    }

    [HttpGet]
    public IActionResult EditArticle(int id)
    {
        if (HttpContext.Session.GetString("Role") != "Contributor")
        {
            return Unauthorized();
        }

        var article = _dbContext.Articles.FirstOrDefault(a => a.ArticleId == id);
        if (article == null || article.ContributorUsername != HttpContext.Session.GetString("Username"))
        {
            return Unauthorized();
        }

        return View(article);
    }

    [HttpPost]
    public IActionResult EditArticle(Article updatedArticle)
    {
        if (HttpContext.Session.GetString("Role") != "Contributor")
        {
            return Unauthorized();
        }

        var article = _dbContext.Articles.FirstOrDefault(a => a.ArticleId == updatedArticle.ArticleId);
        if (article == null || article.ContributorUsername != HttpContext.Session.GetString("Username"))
        {
            return Unauthorized();
        }

        if (ModelState.IsValid)
        {
            article.Title = updatedArticle.Title;
            article.Body = updatedArticle.Body;
            article.StartDate = updatedArticle.StartDate;
            article.EndDate = updatedArticle.EndDate;

            _dbContext.SaveChanges();

            return RedirectToAction("ContributorDashboard");
        }

        return View(updatedArticle);
    }

    [HttpPost]
    public IActionResult DeleteArticle(int id)
    {
        if (HttpContext.Session.GetString("Role") != "Contributor")
        {
            return Unauthorized();
        }

        var article = _dbContext.Articles.FirstOrDefault(a => a.ArticleId == id);
        if (article == null || article.ContributorUsername != HttpContext.Session.GetString("Username"))
        {
            return Unauthorized();
        }

        _dbContext.Articles.Remove(article);
        _dbContext.SaveChanges();

        return RedirectToAction("ContributorDashboard");
    }
}
