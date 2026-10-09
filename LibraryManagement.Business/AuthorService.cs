using LibraryManagement.Data;
using LibraryManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Business
{
    
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _author;
        public AuthorService(IAuthorRepository author)
        {
            _author = author;
        }
        public List<Author> GetAuthor()
        {
            return _author.GetAuthor();
            
        }
    }
}
