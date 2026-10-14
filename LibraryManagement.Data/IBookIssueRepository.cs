using LibraryManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Data
{
    public interface IBookIssueRepository
    {
        CustomResponse AddBookIssues(BookIssue bookissue);
        List<BookIssue> GetBookIssues();
    }
}
