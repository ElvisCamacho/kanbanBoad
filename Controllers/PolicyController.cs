using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roles.Controllers
{
    public class PolicyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Policy ="UserAccess")]
        public IActionResult UserPage()
        {
            return View();
        }
        [Authorize(Policy = "ManagerAccess")]
        public IActionResult ManagerPage()
        {
            return View();
        }
        [Authorize(Policy ="AdminAccess")]
        public IActionResult AdminPage()
        {
            return View();
        }
    }
}
