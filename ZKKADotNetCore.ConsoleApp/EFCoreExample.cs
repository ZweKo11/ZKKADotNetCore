using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZKKADotNetCore.ConsoleApp
{
    internal class EFCoreExample
    {
        private readonly AppDbContext db = new AppDbContext();
        public void Run()
        {
            /*  Read();
              Edit(3);
              Edit(33);*/
            //Create("title", "author", "content");
            //Update(1013, "title update", "author update", "content update");
            Delete(1013);
        }
        private void Read()
        {

            var lst = db.Blogs.ToList();
            foreach (BlogDto item in lst)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogContent);
                Console.WriteLine("--------------------");
            }
        }

        private void Edit(int id)
        {
            var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                Console.WriteLine("No data is found!");
                return;
            }
            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogContent);
        }

        private void Create(string title, string author, string content)
        {
            var item = new BlogDto
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            db.Blogs.Add(item);
            int result = db.SaveChanges();

            string message = result > 0 ? "Saving succeeds." : "Saving Failed";
            Console.WriteLine(message);
        }

        private void Update(int id, string title, string author, string content)
        {
            var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                Console.WriteLine("No data is found!");
                return;
            }

            item.BlogTitle = title;
            item.BlogContent = content;
            item.BlogAuthor = author;

            int result = db.SaveChanges();

            string message = result > 0 ? "Updating succeeds." : "Updating Failed";
            Console.WriteLine(message);
        }

        private void Delete(int id)
        {
            var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                Console.WriteLine("No data is found!");
                return;
            }
            db.Blogs.Remove(item);
            int result = db.SaveChanges();

            string message = result > 0 ? "Deleting succeeds." : "Deleting Failed";
            Console.WriteLine(message);
        }
    }
}
