using Microsoft.AspNetCore.Mvc;

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
