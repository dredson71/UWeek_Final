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
    public class OrderController : ControllerBase
    {

        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                    orderService.GetAll()
                ) ;
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(
                    orderService.Get(id)
                );
        }

        [HttpPost]
        public ActionResult Post([FromBody] Order order)
        {
            return Ok(
                orderService.Save(order)
            );
        }

        [HttpPut]
        public ActionResult Put([FromBody] Order order)
        {
            return Ok(
                orderService.Update(order)
            );
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                orderService.Delete(id)
            );
        }
    }
}
