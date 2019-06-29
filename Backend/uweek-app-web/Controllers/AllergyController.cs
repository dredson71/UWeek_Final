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
    public class AllergyController : ControllerBase
    {

        private readonly IAllergyService allergyService;

        public AllergyController(IAllergyService allergyService)
        {
            this.allergyService = allergyService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                    allergyService.GetAll()
                ) ;
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(
                    allergyService.Get(id)
                );
        }

        [HttpPost]
        public ActionResult Post([FromBody] Allergy allergy)
        {
            return Ok(
                allergyService.Save(allergy)
            );
        }

        [HttpPut]
        public ActionResult Put([FromBody] Allergy allergy)
        {
            return Ok(
                allergyService.Update(allergy)
            );
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                allergyService.Delete(id)
            );
        }
    }
}
