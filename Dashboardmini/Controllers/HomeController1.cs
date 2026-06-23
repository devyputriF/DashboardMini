using Microsoft.AspNetCore.Mvc;

namespace Dashboardmini.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
