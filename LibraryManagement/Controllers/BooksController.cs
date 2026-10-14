using LibraryManagement.Business;
using LibraryManagement.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Formats.Tar;

namespace LibraryManagement.web.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService _book;
        private readonly IAuthorService _author;
        private readonly ICategoryService _category;
        public BooksController(IBookService book, IAuthorService author, ICategoryService category)
        {
            _book = book;
            _author = author;
            _category = category;
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
            var authors = _author.GetAuthor();
            var category = _category.GetCategories();
            //with using lambda function and LINQ
            List<SelectListItem> author = authors.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.AuthorName.ToString(),
                Selected = a.Id == book.AuthorId
            }).ToList();
            ViewBag.authors = author;
            List<SelectListItem> categories = category.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.CategoryName,
                Selected = a.Id == book.CategoryId
            }).ToList();
            ViewBag.category = categories;
            return View(book);
        }
        [HttpPost]
        public IActionResult Edit(Book book)
        {
            CustomResponse response = _book.UpdateBook(book);
            var authors = _author.GetAuthor();
            var category = _category.GetCategories();
            //without using lambda function (simple method)
            List<SelectListItem> author = new List<SelectListItem>();
            foreach (var a in authors)
            {
                SelectListItem item = new SelectListItem();
                item.Value = a.Id.ToString();
                item.Text = a.AuthorName;
                item.Selected = a.Id == book.AuthorId;

                author.Add(item);
            }

            List<SelectListItem> categories = new List<SelectListItem>();
            foreach(var a in category)
            {
                SelectListItem item = new SelectListItem();
                item.Value = a.Id.ToString();
                item.Text=a.CategoryName;
                item.Selected = a.Id == book.CategoryId;
                categories.Add(item);


            }
            ViewBag.authors = author;
            ViewBag.category = categories;
            ViewBag.response = response;
            return View(book);
        }



    }
}
