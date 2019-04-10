using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using notesAppProject.Models;
using StaticHttpContextAccessor.Helpers;

namespace notesAppProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly HomeContext _homeContext;

        public HomeController()
        {
            _homeContext = new HomeContext();
        }

        public IActionResult Index()
        {
            _homeContext.HomeIndexMessage();
            ViewBag.message = _homeContext.GetVisibleMessage();

            return View();
        }
    }
}
