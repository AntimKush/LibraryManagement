using LibraryManagement.Model;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LibraryManagement.Data
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly IConfiguration _configure;
        public AuthorRepository(IConfiguration configure)
        {
            _configure = configure;
        }
        public List<Author> GetAuthor()
        {
            string connectionString = _configure.GetConnectionString("DefaultConnection");
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "dbo.GetAuthor";

            List<Author> lst = new List<Author>();
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Author author = new Author();
                author.Id = Convert.ToInt32(reader["Id"]);
                author.AuthorName = Convert.ToString(reader["AuthorName"]);
                author.AddedBy = Convert.ToString(reader["AddedBy"]);
                author.AddedOn = Convert.ToDateTime(reader["AddedOn"]);
                lst.Add(author);
            }

            conn.Close();
            return lst;



        }


    }


}
