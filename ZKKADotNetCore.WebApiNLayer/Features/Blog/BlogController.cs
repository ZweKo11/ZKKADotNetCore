﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ZKKADotNetCore.WebApiNLayer.Features.Blog
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly BL_Blog _bl_Blog;

        public BlogController()
        {
            _bl_Blog = new BL_Blog();
        }

        [HttpGet]
        public IActionResult Read()
        {
            var lst = _bl_Blog.GetBlogs();
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult Edit(int id)
        {
            var item = _bl_Blog.GetBlog(id);
            if (item is null)
            {
                return NotFound("No data found.");
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create(BlogModel blog)
        {
            var result = _bl_Blog.CreateBlog(blog);

            string message = result > 0 ? "Saving succeeds." : "Saving Failed";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, BlogModel blog)
        {
            var item = _bl_Blog.GetBlog(id);
            if (item is null)
            {
                return NotFound("No data found.");
            }
            var result = _bl_Blog.UpdateBlog(id, blog);

            string message = result > 0 ? "Updating succeeds." : "Updating Failed";
            return Ok(message);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, BlogModel blog)
        {
            var item = _bl_Blog.GetBlog(id);
            if (item is null)
            {
                return NotFound("No data found.");
            }

            if (!string.IsNullOrEmpty(blog.BlogTitle))
            {
                item.BlogTitle = blog.BlogTitle;
            }
            if (!string.IsNullOrEmpty(blog.BlogContent))
            {
                item.BlogContent = blog.BlogContent;
            }
            if (!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                item.BlogAuthor = blog.BlogAuthor;
            }

            var result = _bl_Blog.UpdateBlog(id, blog);

            string message = result > 0 ? "Updating succeeds." : "Updating Failed";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _bl_Blog.GetBlog(id);
            if (item is null)
            {
                return NotFound("No data found.");
            }
          
            var result = _bl_Blog.DeleteBlog(id);

            string message = result > 0 ? "Deleting succeeds." : "Deleting Failed";
            return Ok(message);
        }
    }
}
