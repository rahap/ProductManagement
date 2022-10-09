using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IBusControl _busControl;

            public ProductController(IBusControl busControl)
        {
            _busControl = busControl;
        }

        [HttpPost]
        public ActionResult RegisterProduction()
        {
            return Ok();
        }
    }
}
