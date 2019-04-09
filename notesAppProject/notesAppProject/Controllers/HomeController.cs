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
        //private readonly notesAppProject _context;
        private readonly SessionHandler _sessionHandler;

        public HomeController(SessionHandler sessionHandler)
        {
            //_context = context;
            _sessionHandler = sessionHandler;
        }

        public IActionResult Index()
        {
            var Message = "Sign in or register a new account to proceed.";
            _sessionHandler.SetTempMessage(Message);
            ViewBag.message = Message;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
