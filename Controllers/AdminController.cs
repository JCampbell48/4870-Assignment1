using BlogApp.Data;
using BlogApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;

        public AdminController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public async Task<IActionResult> PendingUsers()
        {
            var pendingUsers = await _context.Users.Where(u => !u.IsApproved).ToListAsync();
            return View(pendingUsers);
        }

        [HttpPost]
        public async Task<IActionResult> ApproveUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                user.IsApproved = true;
                await _userManager.UpdateAsync(user);

                // Ensure the "Contributor" role exists
                if (!await _roleManager.RoleExistsAsync("Contributor"))
                {
                    await _roleManager.CreateAsync(new IdentityRole("Contributor"));
                }
                await _userManager.AddToRoleAsync(user, "Contributor");

                return RedirectToAction("PendingUsers");
            }

            return NotFound();
        }

        public async Task<IActionResult> UserList()
        {
            var users = await _context.Users.ToListAsync();
            var userRoles = new List<(User, IList<string>)>();
            
            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                userRoles.Add((user, roles));
            }

            return View(userRoles);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeRole(string id, string role)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                var roles = await _userManager.GetRolesAsync(user);
                await _userManager.RemoveFromRolesAsync(user, roles.ToArray());
                await _userManager.AddToRoleAsync(user, role);

                return RedirectToAction("UserList");
            }

            return NotFound();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult TestAdminPage()
        {
            return Content("You are an admin!");
        }
    }
}
