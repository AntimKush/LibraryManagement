using LibraryManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Business
{
    public interface IBookService
    {
        List<Book> GetBook();
        Book GetBookById(int id);
        CustomResponse Update_Book(Book book);
    }
}
