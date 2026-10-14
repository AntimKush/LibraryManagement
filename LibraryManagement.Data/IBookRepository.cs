using LibraryManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Data
{
    public interface IBookRepository
    {
        List<Book> GetBook();
        Book GetBookById(int id);
        CustomResponse UpdateBook(Book book);
       
    }
}
