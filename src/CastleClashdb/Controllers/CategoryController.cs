using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CastleClashdb.Services;
using CastleClashdb.Models.CastleClash;
using CastleClashdb.Data;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CastleClashdb.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {

        private CategoryService service;
        private ApplicationDbContext db;
        public CategoryController(CategoryService service, ApplicationDbContext db)
        {
            this.service = service;
            this.db = db;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            //return service.GetAllCategories();
            var item = db.Categories.Include(x => x.Hero).ToList();
            return item;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            //Category cat = service.GetCategoryById(id);
            //if (cat != null)
            //{
            //    return Ok(cat);
            //}
            //return NotFound();

            var item = db.Categories.Include(x => x.Hero)
                .FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                return Ok(item);
            }
            return NotFound();
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Category value)
        {
            var item = service.SaveCategory(value);
            if (item != null)
            {
                return Created("api/category" + item.Id, item);
            }
            return BadRequest("There is no category here.");

            //var cat = db.Categories.FirstOrDefault(x => x.Id == value.);

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Category value)
        {
            service.UpdateCategory(id, value);
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            service.DeleteCategory(id);
            return Ok();
        }
    }
}
