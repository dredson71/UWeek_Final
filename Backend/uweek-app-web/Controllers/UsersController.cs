using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace uweek_app_web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }


        // GET: api/Users
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                    userService.GetAll()
                );
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(
                    userService.Get(id)
                );
        }

        // POST: api/Users
        [HttpPost]
        public ActionResult Post([FromBody] User user)
        {
            return Ok(
                userService.Save(user)
            );
        }

        // PUT: api/Users/5
        [HttpPut]
        public ActionResult Put([FromBody] User user)
        {
            return Ok(
                userService.Update(user)
            );
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                userService.Delete(id)
            );
        }
    }
}
