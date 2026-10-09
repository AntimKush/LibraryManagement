using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
