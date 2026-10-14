using LibraryManagement.Data;
using LibraryManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Business
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _book;

        public BookService(IBookRepository book)
        {
            _book = book;
        }
        public List<Book> GetBook()
        {
            return _book.GetBook();
        }
        public Book GetBookById(int id)
        {
            return _book.GetBookById(id);
        }
        public CustomResponse UpdateBook(Book book)
        {
            return _book.UpdateBook(book);
        }
    }
}
