using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCrud.DaL.Context;
using WebApiCrud.DaL.Entities;

namespace WebApiCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        [HttpGet]
        public IActionResult  Get()
        {
            using var context = new WebApiCrudContext();
            return Ok( context.Categories.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using var context = new WebApiCrudContext();
         var category= context.Categories.Find(id);
            if (category==null)
            {
                return NotFound();
            }
            return Ok(category);
        }
        [HttpPut]
        public IActionResult UpdateCategory(Category c)
        {
            using var context = new WebApiCrudContext();
            var updatecategory = context.Categories.Find(c.Id);
            if (updatecategory==null)
            {
                return NotFound();
            }
            updatecategory.Name = c.Name;
            context.Update(updatecategory);
            context.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            using var context = new WebApiCrudContext();
          var deletedCategory=  context.Categories.Find(id);
            if (deletedCategory==null)
            {
                return NotFound();
            }
            context.Remove(deletedCategory);
            context.SaveChanges();
            return NoContent();
        }
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            using var context = new WebApiCrudContext();
            context.Categories.Add(category);
            context.SaveChanges();
            return Created("",category);
        }

        [HttpGet("{id}/blogs")]
        public IActionResult GetWithBlogsById(int id)
        {
            using var context = new WebApiCrudContext();
            var categoryIdFind = context.Categories.Find(id);
            if (categoryIdFind==null)
            {
                return NotFound();
            }
          var categorywithblogs=  context.Categories.Where(x => x.Id == id).Include(x => x.Blogs).ToList();
            return Ok(categorywithblogs);
        }
    }
}
