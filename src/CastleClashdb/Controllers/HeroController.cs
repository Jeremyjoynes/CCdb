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
    public class HeroController : Controller
    {
        private ApplicationDbContext db;
        private HeroService service;

        public HeroController(HeroService service, ApplicationDbContext db)
        {
            this.service = service;
            this.db = db;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Hero> Get()
        {
             return service.GetAllHeroes();
     
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Hero hero = service.GetHeroById(id);

            if (hero != null)
            {
                return Ok(hero);
            }
            return NotFound();
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Hero value)
        {
            var hero = service.SaveHero(value);
            if (hero != null)
            {
                return Created("api/hero" + hero.Id, hero);
            }
            return BadRequest("Rip there is no hero here!");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Hero value)
        {
            service.UpdateHero(id, value);
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            service.DeleteHero(id);
            return Ok();
        }
    }
}
