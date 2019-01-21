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
        public IActionResult Index(ProfileVm model)
        {
            return View();
        }
    }
}