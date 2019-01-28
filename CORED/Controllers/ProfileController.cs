using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CORED.Models;

namespace CORED.Controllers
{
    public class ProfileController : Controller
    {
        private static readonly string Error = "Please check details again";

        public ActionResult Index(ProfileVm model)
        {
            return View("Signup", model);
        }

        [HttpGet]
        public IActionResult Signup()
        {
            ViewData["Message"] = "Create your account here";

            return View();
        }

        [HttpPost]
        public ActionResult Signup(ProfileVm model)
        {
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, Error);
                return View("Signup", model);
            }
            return View("Signup", model);
        }
    }
}