using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
