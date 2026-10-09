using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Model
{
    public class Author
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string AddedBy { get; set; }
        public DateTime AddedOn { get; set; }

    }
}
