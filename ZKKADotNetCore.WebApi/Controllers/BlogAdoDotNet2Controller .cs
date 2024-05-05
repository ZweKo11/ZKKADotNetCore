using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using ZKKADotNetCore.WebApi.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using ZKKADotNetCore.Shared;
using System.Reflection.Metadata;
using System.Reflection;

namespace ZKKADotNetCore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogAdoDotNet2Controller : ControllerBase
    {
        private readonly AdoDotNetService _adoDotNetService = new AdoDotNetService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);


        [HttpGet]
        public IActionResult GetBlogs() 
        {
            string query = "select * from tbl_blog";

            var lst = _adoDotNetService.Query<BlogModel>(query);

            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {
            var item = FindById(id);
            if (item is null)
            {
                return NotFound("No data is found!");
            }
            string query = "select * from tbl_blog where BlogId = @BlogId";
            SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            //connection.Open();

            //SqlCommand cmd = new SqlCommand(query, connection);
            //cmd.Parameters.AddWithValue("@BlogId", id);
            //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //sqlDataAdapter.Fill(dt);

            //connection.Close();

            //Long form
            //AdoDotNetParameter[] parameters = new AdoDotNetParameter[1];
            //parameters[0] = new AdoDotNetParameter("@BlogId", id);
            //var lst = _adoDotNetService.Query<BlogModel>(query, parameters);

            //Short Form
            var lst = _adoDotNetService.QueryFirstOrDefault<BlogModel>(query, new AdoDotNetParameter("@BlogId", id));

            if (item is null)
            {
                return NotFound("no data is found.");
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult CreateBlog(BlogModel blog)
        {
            string query = @"INSERT INTO [dbo].[tbl_blog]
               ([BlogTitle]
               ,[BlogAuthor]
               ,[BlogContent])
            VALUES
               (@BlogTitle
               ,@BlogAuthor
               ,@BlogContent)";

            int result = _adoDotNetService.Execute(query, 
                new AdoDotNetParameter("@BlogTitle", blog.BlogTitle),
                new AdoDotNetParameter("@BlogAuthor", blog.BlogAuthor),
                new AdoDotNetParameter("@BlogContent", blog.BlogContent)
                );
            string message = result > 0 ? "Saving succeeds." : "Saving Failed";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, BlogModel blog)
        {
            var item = FindById(id);
            if (item is null)
            {
                return NotFound("No data is found!");
            }
            string query = @"UPDATE [dbo].[tbl_blog]
               SET [BlogTitle] = @BlogTitle
                  ,[BlogAuthor] = @BlogAuthor
                  ,[BlogContent] = @BlogContent
             WHERE BlogId = @BlogId";

            int result = _adoDotNetService.Execute(query,
                new AdoDotNetParameter("@BlogId", id),
               new AdoDotNetParameter("@BlogTitle", blog.BlogTitle),
               new AdoDotNetParameter("@BlogAuthor", blog.BlogAuthor),
               new AdoDotNetParameter("@BlogContent", blog.BlogContent)
               );

            string message = result > 0 ? "Updating succeeds." : "Updating failed";
            return Ok(message);
        }

        [HttpPatch ("{id}")]
       public IActionResult PatchBlog(int id, BlogModel blog)
        {
            var item = FindById(id);
            if (item is null)
            {
                return NotFound("No data is found!");
            }
            List<AdoDotNetParameter> lst = new List<AdoDotNetParameter>();

            string conditions = string.Empty;
            if (!string.IsNullOrEmpty(blog.BlogTitle))
            {
                conditions += "[BlogTitle] = @BlogTitle,";
                lst.Add(new AdoDotNetParameter("@BlogTitle", blog.BlogTitle));
            }
            if (!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                conditions += "[BlogAuthor] = @BlogAuthor,";
                lst.Add(new AdoDotNetParameter("@BlogAuthor", blog.BlogAuthor));
            }
            if (!string.IsNullOrEmpty(blog.BlogContent))
            {
                conditions += "[BlogContent] = @BlogContent,";
                lst.Add(new AdoDotNetParameter("@BlogContent", blog.BlogContent));
            }
            lst.Add(new AdoDotNetParameter("@BlogId", id));
            if (conditions.Length == 0)
            {
                return NotFound("no data is found.");
            }
            conditions = conditions.Substring(0, conditions.Length - 1);
            blog.BlogId = id;
            string query = $@"UPDATE [dbo].[tbl_blog]
               SET {conditions}
             WHERE BlogId = @BlogId";
         
            int result = _adoDotNetService.Execute(query, lst.ToArray());
            string message = result > 0 ? "Updating succeeds." : "Updating failed";

           return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id,BlogModel blog)
        {
            var item = FindById(id);
            if (item is null)
            {
                return NotFound("No data is found!");
            }

            string query = @"delete from tbl_blog where BlogId = @BlogId";
            int result = _adoDotNetService.Execute(query,
               new AdoDotNetParameter("@BlogId", id),
               new AdoDotNetParameter("@BlogTitle", blog.BlogTitle),
               new AdoDotNetParameter("@BlogAuthor", blog.BlogAuthor),
               new AdoDotNetParameter("@BlogContent", blog.BlogContent)
               );
            string message = result > 0 ? "Deleting succeeds." : "Deleting failed";
            return Ok(message);
        }

        private BlogModel? FindById(int id)
        {
            string query = "select * from tbl_blog where blogId = @BlogId";
            using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            var item = db.Query<BlogModel>(query, new BlogModel { BlogId = id }).FirstOrDefault();
            return item;
        }
    }
}
