using LibraryManagement.Model;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace LibraryManagement.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IConfiguration _configuration;
        public CategoryRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<Category> GetCategories()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "dbo.GetCategory";
            List<Category> lst = new List<Category>();
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Category category = new Category();
                category.Id = Convert.ToInt32(reader["Id"]);
                category.CategoryName = Convert.ToString(reader["CategoryName"]);

                lst.Add(category);
                
            }
            conn.Close();
            return lst;
        }
    }
}
