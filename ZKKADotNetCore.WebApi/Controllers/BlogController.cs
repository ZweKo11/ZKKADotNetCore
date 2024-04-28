using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using ZKKADotNetCore.WebApi.Database;
using ZKKADotNetCore.WebApi.Models;

namespace ZKKADotNetCore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly AppDbContext _context;
        public BlogController()
        {
            _context = new AppDbContext();
        }
        [HttpGet]
        public IActionResult Read()
        {
            var lst = _context.Blogs.ToList();
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult Edit(int id)
        {
            var item = _context.Blogs.FirstOrDefault(x=>x.BlogId == id);
            if(item is null)
            {
                return NotFound("No data found.");
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create(BlogModel blog)
        {
            _context.Blogs.Add(blog);
            var result = _context.SaveChanges();

            string message = result > 0 ? "Saving succeeds." : "Saving Failed";
  
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, BlogModel blog)
        {
            var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return NotFound("No data found.");
            }
            item.BlogTitle = blog.BlogTitle;
            item.BlogContent = blog.BlogContent;
            item.BlogAuthor = blog.BlogAuthor;

            var result = _context.SaveChanges();

            string message = result > 0 ? "Updating succeeds." : "Updating Failed";
            return Ok(message);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, BlogModel blog)
        {
            var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return NotFound("No data found.");
            }

            if (!string.IsNullOrEmpty(item.BlogTitle))
            {
                item.BlogTitle = blog.BlogTitle;
            }
            if (!string.IsNullOrEmpty(item.BlogContent))
            {
                item.BlogContent = blog.BlogContent;
            }
            if (!string.IsNullOrEmpty(item.BlogAuthor))
            {
                item.BlogAuthor = blog.BlogAuthor;
            }

            var result = _context.SaveChanges();

            string message = result > 0 ? "Updating succeeds." : "Updating Failed";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return NotFound("No data found.");
            }
            _context.Blogs.Remove(item);

            var result = _context.SaveChanges();

            string message = result > 0 ? "Deleting succeeds." : "Deleting Failed";
            return Ok(message);
        }
    }
}
