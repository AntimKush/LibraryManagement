using LibraryManagement.Business;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.web.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService _book;
        public BooksController(IBookService book)
        {
            _book = book ;
        }
        public IActionResult Index()
        {
            var books = _book.GetBook();
            return View(books);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var book = _book.GetBookById(id);
            return View(book);
        }
    }
}
