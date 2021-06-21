using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalE.Domain.ComboxManager;
using TechnicalE.Interfaces.Generic;

namespace TechnicalE.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComboxController : ControllerBase
    {
        private readonly IComboxManager _combox;

        public ComboxController(IComboxManager combox)
        {
            _combox = combox;
        }

        [HttpGet]
        [Route("Currency")]
        public async Task<IActionResult> CurrencyCombox()
        {
            try
            {                
                return StatusCode(200, await _combox.CurrencyCodeCombox());
            }
            catch (Exception err)
            {
                return StatusCode(500, err.Message);
            }
        }
    }
}
