using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.web.Controllers
{
    public class BookIssueController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
