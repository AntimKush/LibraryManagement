using LibraryManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Data
{
    public interface ICategoryRepository
    {
        List<Category> GetCategories();
    }
}
