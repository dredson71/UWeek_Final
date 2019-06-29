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
    public class IngredientsController : ControllerBase
    {

        private readonly IIngredientService ingredientService;

        public IngredientsController(IIngredientService ingredientService)
        {
            this.ingredientService = ingredientService;
        }

        // GET: api/Plans
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                    ingredientService.GetAll()
                ) ;
        }

        // GET: api/Plans/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(
                    ingredientService.Get(id)
                );
        }

        // POST: api/Plans
        [HttpPost]
        public ActionResult Post([FromBody] Ingredient ingredient)
        {
            return Ok(
                ingredientService.Save(ingredient)
            );
        }

        // PUT: api/Plans/5
        [HttpPut]
        public ActionResult Put([FromBody] Ingredient ingredient)
        {
            return Ok(
                ingredientService.Update(ingredient)
            );
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                ingredientService.Delete(id)
            );
        }
    }
}
