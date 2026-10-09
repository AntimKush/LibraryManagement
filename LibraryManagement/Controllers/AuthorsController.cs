using LibraryManagement.Business;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.web.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly IAuthorService _author;
        public AuthorsController(IAuthorService author)
        {
            _author = author;
        }
        public IActionResult Index()
        {
            var authors = _author.GetAuthor();
            return View(authors);
        }
    }
}
