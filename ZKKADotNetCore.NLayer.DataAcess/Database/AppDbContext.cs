using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZKKADotNetCore.NLayer.DataAcess;
using ZKKADotNetCore.NLayer.DataAcess.Database;
using ZKKADotNetCore.NLayer.DataAcess.Models;

namespace ZKKADotNetCore.NLayer.DataAcess.Database
{
    internal class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        }
        public DbSet<BlogModel> Blogs { get; set; }
    }
}
