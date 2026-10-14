using LibraryManagement.Model;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LibraryManagement.Data
{
    public class MemberRepository : IMemberRepository
    {
        private readonly IConfiguration _configuration;
        public MemberRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<Members> GetMembers() 
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "dbo.GetMembers";
            List<Members> lst = new List<Members>();
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Members member = new Members();
                member.Id = Convert.ToInt32(reader["Id"]);
                member.MemberName = Convert.ToString(reader["MemberName"]);
                member.Email = Convert.ToString(reader["Email"]);
                member.Mobile_No = Convert.ToString(reader["Mobile_No"]);
                member.Address = Convert.ToString(reader["Address"]);
                member.Join_Date = Convert.ToString(reader["Join_Date"]);

                lst.Add(member);


            }
            conn.Close();
            return lst;

        }
    }
}
