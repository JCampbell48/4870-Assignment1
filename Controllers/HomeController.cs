using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using BlogApp.Models;
using BlogApp.Data;
using System.Diagnostics;
using System.Linq;

namespace BlogApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<User> _userManager;

        // Constructor to inject necessary dependencies
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext, UserManager<User> userManager)
        {
            _logger = logger;
            _dbContext = dbContext;
            _userManager = userManager;
        }

        // Action to display the homepage
        public IActionResult Index()
        {
            var articles = _dbContext.Articles.ToList();
            return View(articles);
        }

        // Action to display all articles
        public IActionResult AllArticles()
        {
            var articles = _dbContext.Articles.ToList(); 
            return View(articles);
        }

        // Action to display a single article
        public IActionResult Article(int id)
        {
            var article = _dbContext.Articles.FirstOrDefault(a => a.ArticleId == id);
            
            if (article == null)
            {
                return NotFound(); 
            }

            return View(article);
        }

        // Privacy page
        public IActionResult Privacy()
        {
            return View();
        }

        // Action for handling errors
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
