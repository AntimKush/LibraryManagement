using LibraryManagement.Model;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LibraryManagement.Data
{
    public class BookIssueRepository : IBookIssueRepository
    {
        private readonly IConfiguration _configuration;

        public BookIssueRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public CustomResponse AddBookIssues(BookIssue bookissue)
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "dbo.AddBookIssue";
            cmd.Parameters.AddWithValue("@BookId" , bookissue.BookId);
            cmd.Parameters.AddWithValue("@MemberId", bookissue.MemberId);
            cmd.Parameters.AddWithValue("@IssueDate", bookissue.IssueDate);
            cmd.Parameters.AddWithValue("@DueDate", bookissue.DueDate);

            CustomResponse customResponse = new CustomResponse();

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                var status = reader["Status"].ToString();
                var message = reader["Message"].ToString();

                customResponse.IsSuccess = status.ToUpper().Contains("SUCCESS");
                customResponse.Message = message;

                return customResponse;
            }
            conn.Close();
            customResponse.IsSuccess = false;
            customResponse.Message = "Error";

            return customResponse;




        }

        public List<BookIssue> GetBookIssues()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "dbo.GetBookIssue";
            List<BookIssue> lst = new List<BookIssue>();
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                BookIssue book = new BookIssue();
                book.Id = Convert.ToInt32(reader["Id"]);
                book.BookId = Convert.ToInt32(reader["BookId"]);
                book.BookName = reader["BookName"].ToString();
                book.MemberId = Convert.ToInt32(reader["MemberId"]);
                book.MemberName = reader["MemberName"].ToString();
                book.IssueDate = Convert.ToDateTime(reader["IssueDate"]);
                book.DueDate = Convert.ToDateTime(reader["DueDate"]);
                if (reader["ReturnDate"] == DBNull.Value)
                {
                    book.ReturnDate = null;
                }
                else
                {
                    book.ReturnDate = Convert.ToDateTime(reader["ReturnDate"]);
                }

                lst.Add(book);

            }
            conn.Close();
            return lst;
        }
    }
}
