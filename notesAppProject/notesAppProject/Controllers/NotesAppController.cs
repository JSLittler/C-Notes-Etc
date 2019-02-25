using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using notesAppProject.Models;
using StaticHttpContextAccessor.Helpers;
using MongoDB.Driver;
using notesAppProject.Models;

namespace notesAppProject.Controllers
{
    public class NotesAppController : Controller
    {
        //private readonly notesAppProject _context;
        private readonly SessionHandler _sessionHandler;

        public NotesAppController(SessionHandler sessionHandler)
        {
            //_context = context;
            _sessionHandler = sessionHandler;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
