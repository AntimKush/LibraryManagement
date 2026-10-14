using LibraryManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Business
{
    public interface IBookIssueService
    {
        List<BookIssue> GetBookIssues();
        CustomResponse AddBookIssues(BookIssue bookissue);
    }
}
