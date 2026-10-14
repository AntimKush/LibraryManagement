using LibraryManagement.Business;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.web.Controllers
{
    public class MembersController : Controller
    {
        private readonly IMemberService _member;
        public MembersController(IMemberService member)
        {
            _member = member;
        }
        public IActionResult Index()
        {
            var result = _member.GetMembers();
            return View(result);
        }
    }
}
