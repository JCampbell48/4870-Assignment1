using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BlogApp.Data;
using BlogApp.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace BlogApp.Controllers
{
    [Authorize(Roles = "Contributor")]
    public class ContributorController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<ContributorController> _logger;

        // Ensure logger is injected
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
            // Debug: Check session values
            var userRole = HttpContext.Session.GetString("Role");
            var username = HttpContext.Session.GetString("Username");

            if (string.IsNullOrEmpty(userRole) || userRole != "Contributor" || string.IsNullOrEmpty(username))
            {
                // Log the session state for debugging
                _logger.LogWarning("Unauthorized access attempt. Role: {Role}, Username: {Username}", userRole, username);
                return Unauthorized(); // Return 401 if session data is missing or incorrect
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
