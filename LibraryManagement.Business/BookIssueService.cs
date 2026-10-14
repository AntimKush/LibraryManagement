using LibraryManagement.Data;
using LibraryManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Business
{
    public class BookIssueService : IBookIssueService
    {
        private readonly IBookIssueRepository _bookIssue;
        public BookIssueService(IBookIssueRepository bookIssue)
        {
            _bookIssue = bookIssue;
        }
        public List<BookIssue> GetBookIssues()
        {
            return _bookIssue.GetBookIssues();
        }
        public CustomResponse AddBookIssues(BookIssue bookIssue)
        {
            return _bookIssue.AddBookIssues(bookIssue);
        }

        
    }
}
