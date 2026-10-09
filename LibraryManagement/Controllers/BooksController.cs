using LibraryManagement.Business;
using LibraryManagement.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryManagement.web.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService _book;
        private readonly IAuthorService authorService;

        public BooksController(IBookService book, IAuthorService authorService)
        {
            _book = book;
            this.authorService = authorService;
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
            var authors = authorService.GetAuthor();

            List<SelectListItem> Authors = authors.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.AuthorName,
                Selected=a.Id== book.AuthorId
            }).ToList();

            ViewBag.Authors = Authors;
            return View(book);
        }
        [HttpPost]
        public IActionResult Edit(Book book)
        {
            CustomResponse result = _book.Update_Book(book);

            var authors = authorService.GetAuthor();

            List<SelectListItem> Authors = new List<SelectListItem>();

            foreach (var currentAuthor in authors)
            {
                bool IsSelected = currentAuthor.Id == book.AuthorId;
                Authors.Add(new SelectListItem() { Value = currentAuthor.Id.ToString(), Text = currentAuthor.AuthorName,Selected= IsSelected });
            }
            
            ViewBag.Authors = Authors;


            ViewBag.Response = result;
            return View(book);
        }
    }
}
