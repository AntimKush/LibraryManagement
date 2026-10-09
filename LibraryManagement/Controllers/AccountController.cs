using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
