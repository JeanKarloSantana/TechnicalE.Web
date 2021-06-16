using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnicalE.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestingController : ControllerBase
    {
        public TestingController() 
        {
        }

        [HttpGet]        
        public IActionResult GetRate()
        {
            try
            {
                return StatusCode(200, "This is a test");

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
