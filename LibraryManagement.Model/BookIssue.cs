using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Model
{
    public class BookIssue
    {
        public int Id { get; set; }

        public int BookId { get; set; }
        public string BookName { get; set; }
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public DateTime  IssueDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
