using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BlogApp.Data;
using BlogApp.Models;

namespace BlogApp.Controllers
{
    [Authorize(Roles = "Contributor,Admin")]
    public class ContributorController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<ContributorController> _logger;

        public ContributorController(ApplicationDbContext dbContext, ILogger<ContributorController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult ContributorDashboard()
        {
            var username = User.Identity.Name; // Get logged-in username
            var articles = _dbContext.Articles.Where(a => a.ContributorUsername == username).ToList();
            return View(articles);
        }

        [HttpGet]
        public IActionResult CreateArticle()
        {
            return View();
        }

[HttpPost]
public IActionResult CreateArticle(Article article)
{
    var username = User.Identity.Name;

    if (!User.IsInRole("Contributor") && !User.IsInRole("Admin"))
    {
        _logger.LogWarning("Unauthorized access attempt by user: {Username}", username);
        return Unauthorized(); // 401 Unauthorized
    }

    if (ModelState.IsValid)
    {
        article.ContributorUsername = username;
        var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
        article.CreateDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZoneInfo);

        _dbContext.Articles.Add(article);
        _dbContext.SaveChanges();

        return RedirectToAction("ContributorDashboard");
    }

    return View(article);
}


        [HttpGet]
        public IActionResult EditArticle(int id)
        {
            var article = _dbContext.Articles.FirstOrDefault(a => a.ArticleId == id);
            if (article == null || article.ContributorUsername != User.Identity.Name)
            {
                return Unauthorized();
            }

            return View(article);
        }

        [HttpPost]
        public IActionResult EditArticle(Article updatedArticle)
        {
            var article = _dbContext.Articles.FirstOrDefault(a => a.ArticleId == updatedArticle.ArticleId);
            if (article == null || article.ContributorUsername != User.Identity.Name)
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
            var article = _dbContext.Articles.FirstOrDefault(a => a.ArticleId == id);
            if (article == null || article.ContributorUsername != User.Identity.Name)
            {
                return Unauthorized();
            }

            _dbContext.Articles.Remove(article);
            _dbContext.SaveChanges();

            return RedirectToAction("ContributorDashboard");
        }
    }
}
