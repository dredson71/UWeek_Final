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
    public class DishesController : ControllerBase
    {

        private readonly IDishService dishService;

        public DishesController(IDishService dishService)
        {
            this.dishService = dishService;
        }

        // GET: api/Plans
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                    dishService.GetAll()
                ) ;
        }

        // GET: api/Plans/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(
                    dishService.Get(id)
                );
        }

        // POST: api/Plans
        [HttpPost]
        public ActionResult Post([FromBody] Dish dish)
        {
            return Ok(
                dishService.Save(dish)
            );
        }

        // PUT: api/Plans/5
        [HttpPut]
        public ActionResult Put([FromBody] Dish dish)
        {
            return Ok(
                dishService.Update(dish)
            );
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                dishService.Delete(id)
            );
        }
    }
}
