using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCrud.DaL.Entities;

namespace WebApiCrud.DaL.Context
{
    public class WebApiCrudContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server = MEHDI; database = Api2021; integrated security = true; ");
           
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Blog> Blogs { get; set; }
    }
}
