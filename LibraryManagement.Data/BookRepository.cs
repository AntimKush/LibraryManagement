using LibraryManagement.Model;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LibraryManagement.Data
{
    public class BookRepository : IBookRepository
    {
        private readonly IConfiguration _configuration;

        public BookRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<Book> GetBook()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "dbo.GetBook";

            List<Book> lst = new List<Book>();

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Book book = new Book();
                book.Id = Convert.ToInt32(reader["Id"]);
                book.BookName = Convert.ToString(reader["BookName"]);
                book.AuthorName = Convert.ToString(reader["AuthorName"]);
                book.AuthorId = Convert.ToInt32(reader["AuthorId"]);
                book.CategoryId = Convert.ToInt32(reader["Id"]);
                book.CategoryName = Convert.ToString(reader["CategoryName"]);
                book.ISBN = Convert.ToString(reader["ISBN"]);
                book.Price = Convert.ToDecimal(reader["Price"]);
                book.Quantity = Convert.ToInt32(reader["Quantity"]);
                lst.Add(book);
                
                


            }
            conn.Close();
            return lst;
        }
        public Book GetBookById(int id)
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "dbo.GetBookById";
            cmd.Parameters.AddWithValue("@Id", id);
            Book book = null;
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                book = new Book();
                book.Id = Convert.ToInt32(reader["Id"]);
                book.BookName = Convert.ToString(reader["BookName"]);
                book.AuthorName = Convert.ToString(reader["AuthorName"]);
                book.AuthorId = Convert.ToInt32(reader["AuthorId"]);
                book.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                book.CategoryName = Convert.ToString(reader["CategoryName"]);
                book.ISBN = Convert.ToString(reader["ISBN"]);
                book.Price = Convert.ToDecimal(reader["Price"]);
                book.Quantity = Convert.ToInt32(reader["Quantity"]);
            }
            conn.Close();
            return book;
        }
        public CustomResponse UpdateBook(Book book)
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "dbo.UpdateBook";

            cmd.Parameters.AddWithValue("@Id", book.Id);
            cmd.Parameters.AddWithValue("@BookName", book.BookName);
            cmd.Parameters.AddWithValue("@AuthorId", book.AuthorId);
            cmd.Parameters.AddWithValue("@ISBN", book.ISBN);
            cmd.Parameters.AddWithValue("@Price", book.Price);
            cmd.Parameters.AddWithValue("@Quantity", book.Quantity);
            CustomResponse customresponse = new CustomResponse();

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                var status = reader["Status"].ToString();
                var message = reader["Message"].ToString();

                customresponse.IsSuccess = status.ToUpper().Contains("SUCCESS");
                customresponse.Message = message;

                return customresponse;
            }
            conn.Close();
            customresponse.IsSuccess = false;
            customresponse.Message = "Error";

            return customresponse;



        }


    }
}
