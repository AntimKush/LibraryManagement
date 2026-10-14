using LibraryManagement.Business;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _category;
        public CategoriesController(ICategoryService category)
        {
            _category = category;
        }
        public IActionResult Index()
        {
            var result = _category.GetCategories();
            return View(result);
        }
    }
}
