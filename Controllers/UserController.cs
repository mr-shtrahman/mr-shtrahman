using Microsoft.AspNetCore.Mvc;
using mr_shtrahman.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectDBContext = mr_shtrahman.Data.Context;

namespace mr_shtrahman.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public IActionResult Index()
        {
            return View();
        }

        // GET: User/Search
        public ActionResult Search(string email = null)
        {
            return RedirectToAction("Index", "Error", new { message = "You have to login first.." });
        }

        // POST: User/Login
        [HttpPost]
        public ActionResult Login([FromBody] User user)
        {
            // TODO: If the user exists in DB - check if the user is an admin
            // Else - this is the first login, save the user in DB

            return Json(user);
        }

        // GET: User/Logoff
        public ActionResult Logout()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
