using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Reflection.Metadata;

namespace ZKKADotNetCore.ConsoleApp.AdoDotNetExamples
{
    internal class AdoDotNetExample
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "DESKTOP-49VCNU9", //server name
            InitialCatalog = "DotNetTrainingBatch4",
            UserID = "sa",
            Password = "sa@123"
        };
        public void Read()
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

            connection.Open();
            Console.WriteLine("Connection open");

            string query = "select * from tbl_blog";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            connection.Close();
            Console.WriteLine("Connection close");

            //dataset => dataTable
            //dataTable => dataRow
            //dataRow => dataColumn
            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine("Blog Id =>" + dr["BlogId"]);
                Console.WriteLine("Blog Title =>" + dr["BlogTitle"]);
                Console.WriteLine("Blog Author =>" + dr["BlogAuthor"]);
                Console.WriteLine("Blog Content =>" + dr["BlogContent"]);
                Console.WriteLine("-----------------------------");
            }
        }

        public void Edit(int id)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

            connection.Open();
            Console.WriteLine("Connection open");

            string query = "select * from tbl_blog where BlogId = @BlogId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("BlogId", id);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            connection.Close();
            Console.WriteLine("Connection close");

            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("No data found.");
                return;
            }

            DataRow dr = dt.Rows[0];

            Console.WriteLine("Blog Id =>" + dr["BlogId"]);
            Console.WriteLine("Blog Title =>" + dr["BlogTitle"]);
            Console.WriteLine("Blog Author =>" + dr["BlogAuthor"]);
            Console.WriteLine("Blog Content =>" + dr["BlogContent"]);
            Console.WriteLine("-----------------------------");

        }
        public void Create(string title, string author, string content)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

            connection.Open();

            string query = @"INSERT INTO [dbo].[tbl_blog]
               ([BlogTitle]
               ,[BlogAuthor]
               ,[BlogContent])
            VALUES
               (@BlogTitle
               ,@BlogAuthor
               ,@BlogContent)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);
            int result = cmd.ExecuteNonQuery();

            connection.Close();
            string message = result > 0 ? "Saving succeeds." : "Saving Failed";
            Console.WriteLine(message);
        }

        public void Update(int id, string title, string author, string content)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

            connection.Open();

            string query = @"UPDATE [dbo].[tbl_blog]
               SET [BlogTitle] = @BlogTitle
                  ,[BlogAuthor] = @BlogAuthor
                  ,[BlogContent] = @BlogContent
             WHERE BlogId = @BlogId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);
            int result = cmd.ExecuteNonQuery();

            connection.Close();
            string message = result > 0 ? "Updating succeeds." : "Updating failed";
            Console.WriteLine(message);
        }

        public void Delete(int id)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

            connection.Open();

            string query = @"delete from tbl_blog where BlogId = @BlogId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            int result = cmd.ExecuteNonQuery();

            connection.Close();
            string message = result > 0 ? "Deleting succeeds." : "Deleting failed";
            Console.WriteLine(message);
        }
    }
}
