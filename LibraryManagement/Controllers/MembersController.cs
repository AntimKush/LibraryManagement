using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.web.Controllers
{
    public class MembersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
