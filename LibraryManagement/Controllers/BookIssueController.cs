using LibraryManagement.Business;
using LibraryManagement.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryManagement.web.Controllers
{
    public class BookIssueController : Controller
    {
        private readonly IBookIssueService _BookIssue;
        private readonly IBookService _book;
        private readonly IMemberService _member;
        public BookIssueController(IBookIssueService bookIssue , IBookService book, IMemberService member)
        {
            _BookIssue = bookIssue;
            _book = book;
            _member = member;
        }

        
        public IActionResult Index()
        {
            var result = _BookIssue.GetBookIssues();
            return View(result);
        }
        [HttpGet]
        public IActionResult Add()
        {
            var book = _book.GetBook();
            var member = _member.GetMembers();

            List<SelectListItem> books = book.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.BookName,
               
            }).ToList();
            List<SelectListItem> members = member.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.MemberName
            }).ToList();


            ViewBag.bookName = books;
            ViewBag.memberName = members;
            return View();
        }
        [HttpPost]
        public IActionResult Add(BookIssue bookIssue)
        {
            var response = _BookIssue.AddBookIssues(bookIssue);
            ViewBag.response = response;
            return View();
        }
        
    }

    
}
