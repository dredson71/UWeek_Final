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
    public class SuscriptionController : ControllerBase
    {

        private readonly ISuscriptionService suscriptionService;

        public SuscriptionController(ISuscriptionService suscriptionService)
        {
            this.suscriptionService = suscriptionService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                    suscriptionService.GetAll()
                ) ;
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(
                    suscriptionService.Get(id)
                );
        }

        [HttpPost]
        public ActionResult Post([FromBody] Suscription suscription)
        {
            return Ok(
                suscriptionService.Save(suscription)
            );
        }

        [HttpPut]
        public ActionResult Put([FromBody] Suscription suscription)
        {
            return Ok(
                suscriptionService.Update(suscription)
            );
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                suscriptionService.Delete(id)
            );
        }
    }
}
