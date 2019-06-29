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
    public class PlansController : ControllerBase
    {

        private readonly IPlanService planService;

        public PlansController(IPlanService planService)
        {
            this.planService = planService;
        }

        // GET: api/Plans
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                    planService.GetAll()
                ) ;
        }

        // GET: api/Plans/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(
                    planService.Get(id)
                );
        }

        // POST: api/Plans
        [HttpPost]
        public ActionResult Post([FromBody] Plan plan)
        {
            return Ok(
                planService.Save(plan)
            );
        }

        // PUT: api/Plans/5
        [HttpPut]
        public ActionResult Put([FromBody] Plan plan)
        {
            return Ok(
                planService.Update(plan)
            );
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                planService.Delete(id)
            );
        }
    }
}
