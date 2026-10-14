using LibraryManagement.Data;
using LibraryManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Business
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _category;
        public CategoryService(ICategoryRepository category)
        {
            _category = category;
        }

        public List<Category> GetCategories()
        {
            return _category.GetCategories();
        }
    }
}
