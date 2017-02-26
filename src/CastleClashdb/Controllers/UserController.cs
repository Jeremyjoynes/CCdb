using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CastleClashdb.Data;
using CastleClashdb.Models.CastleClash;
using CastleClashdb.Services;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CastleClashdb.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        //private ApplicationDbContext db;
        private UserService service;

        public UserController(UserService service)
        {
            this.service = service;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return service.GetAllUsers();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            User item = service.GetUserById(id);
            if (item != null)
            {
                return Ok(item);
            }
            return NotFound();
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]User value)
        {
            //checks to see if user is admin
            
            if (!User.HasClaim("IsAdmin", "true"))
            {
                return Unauthorized();
            }

            //if user is admin will continue
            var item = service.SaveUser(value);
            if (item != null)
            {
                return Created("api/user" + item.Id, item);
            }
            return BadRequest("could not insert");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]User value)
        {
            service.UpdateUser(id, value);
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            service.DeleteUser(id);
            return Ok();
        }
    }
}
