using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using ZKKADotNetCore.Shared;
using ZKKADotNetCore.WebApi.Models;

namespace ZKKADotNetCore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogDapper2Controller : ControllerBase
    {
        private readonly DapperService _dapperService = new DapperService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        //Read
        [HttpGet]
        public IActionResult GetBlogs()
        {
            string query = "select * from tbl_blog";

            var lst= _dapperService.Query<BlogModel>(query);
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {
            /* string query = "select * from tbl_blog where blogId = @BlogId";
             using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
             var item = db.Query<BlogModel>(query, new BlogModel { BlogId = id }).FirstOrDefault();*/
            var item = FindById(id);
            if (item is null)
            {
                return NotFound("No data is found!");
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
            int result = _dapperService.Execute(query, blog);

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
            blog.BlogId = id;
            string query = @"UPDATE [dbo].[tbl_blog]
               SET [BlogTitle] = @BlogTitle
                  ,[BlogAuthor] = @BlogAuthor
                  ,[BlogContent] = @BlogContent
             WHERE BlogId = @BlogId";

            int result = _dapperService.Execute(query, blog);

            string message = result > 0 ? "Updating succeeds." : "Updating Failed";
            return Ok(message);
        }

        [HttpPatch("{id}")]
        public IActionResult PatchBlog(int id, BlogModel blog)
        {
            var item = FindById(id);
            if (item is null)
            {
                return NotFound("No data is found!");
            }
            string conditions = string.Empty;
            if (!string.IsNullOrEmpty(blog.BlogTitle))
            {
                conditions += "[BlogTitle] = @BlogTitle,";
            }
            if (!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                conditions += "[BlogAuthor] = @BlogAuthor,";
            }
            if (!string.IsNullOrEmpty(blog.BlogContent))
            {
                conditions += "[BlogContent] = @BlogContent,";
            }
            if(conditions.Length == 0)
            {
                return NotFound("no data is found.");
            }
            conditions = conditions.Substring(0, conditions.Length - 1);
            blog.BlogId = id;
            string query =$@"UPDATE [dbo].[tbl_blog]
               SET {conditions}
             WHERE BlogId = @BlogId";

            int result = _dapperService.Execute(query, blog);

            string message = result > 0 ? "Updating succeeds." : "Updating Failed";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            var item = FindById(id);
            if (item is null)
            {
                return NotFound("No data is found!");
            }
            string query = @"DELETE FROM [dbo].[tbl_blog] WHERE BlogId = @BlogId";

            int result = _dapperService.Execute(query, new BlogModel { BlogId = id });

            string message = result > 0 ? "Deleting succeeds." : "Deleting Failed";
            return Ok(message);
        }

        private BlogModel? FindById(int id)
        {
            string query = "select * from tbl_blog where blogId = @BlogId";

            var item = _dapperService.QueryFirstOrDefault<BlogModel>(query, new BlogModel { BlogId = id });
            return item;
        }
    }
}
