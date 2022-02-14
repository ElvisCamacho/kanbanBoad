using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Roles.Data;
using Roles.Models;
using Roles.ViewModel;
using System.Linq;
using System.Threading.Tasks;

namespace Roles.Controllers
{
    [Authorize(Roles ="Admin")]
    public class RolesController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;              

        public RolesController(UserManager<IdentityUser> userManager, ApplicationDbContext context, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _context = context;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var roles = _context.Roles.ToList();
            var users = _context.Users.ToList();
            var userRoles = _context.UserRoles.ToList();

            var convertedUsers = users.Select(x => new UsersVm
            {
                Email = x.Email,
                Roles = roles
                    .Where(y => userRoles.Any(z => z.UserId == x.Id && z.RoleId == y.Id))
                    .Select(y => new UserRole
                    {
                        Name = y.NormalizedName
                    })
            });

            return View(new DisplayVm
            {
                Roles = roles.Select(x => x.NormalizedName),
                Users = convertedUsers
            });
        }
        // Create user
        public async Task<IActionResult> CreateUser(string email)
        {
            var user = new IdentityUser
            {
                UserName = email,
                Email = email
            };

            await _userManager.CreateAsync(user, "PASSWORd!");

            return RedirectToAction("Index");
        }
        // Create Role
        public async Task<IActionResult> CreateRole(RoleVm vm)
        {
            await _roleManager.CreateAsync(new IdentityRole { Name = vm.Name });

            return RedirectToAction("Index");
        }

        // Update User Role
        public async Task<IActionResult> UpdateUserRole(UpdateUserRoleVm vm)
        {
            if (vm != null)
            {
                var user = await _userManager.FindByEmailAsync(vm.UserEmail);

                if (vm.Delete)
                    await _userManager.RemoveFromRoleAsync(user, vm.Role);
                else
                    await _userManager.AddToRoleAsync(user, vm.Role);
            }          

            return RedirectToAction("Index");
        }
    }
}
