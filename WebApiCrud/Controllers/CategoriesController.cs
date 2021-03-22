using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
