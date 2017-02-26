using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CastleClashdb.Data;
using CastleClashdb.Models.CastleClash;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CastleClashdb.Controllers
{
    [Route("api/[controller]")]
    public class AlterHeroController : Controller
    {
        private ApplicationDbContext db;
        public AlterHeroController(ApplicationDbContext db)
        {
            this.db = db;
        }

        // GET: api/values
       //[HttpGet]
       //public IEnumerable<AlterHeroes> Get()
       // {
       //     //var item = db.Categories.Include(x => x.Hero);
       //     var item = db.Heroes.Include(x => x.Categories);
       //     var list = item.Select(m => new AlterHeroes()
       //     {
       //       HeroId = m.
       //         .Select(x => x.User).ToList()
       //     }).ToList();
            

       // }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        
    }
}
