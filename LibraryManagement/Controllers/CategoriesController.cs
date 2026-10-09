using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.web.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
