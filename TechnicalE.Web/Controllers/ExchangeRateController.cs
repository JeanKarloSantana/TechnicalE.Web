using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalE.Domain.ExchangeRatesManager;
using TechnicalE.Domain.PurchaseTransactionManager;
using TechnicalE.Entities.DTO;
using TechnicalE.Interfaces.Generic;

namespace TechnicalE.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]    
    public class ExchangeRateController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExchangeRateManager _exchangeRate;
        
        public ExchangeRateController(IUnitOfWork unitOfWork, IExchangeRateManager exchangeRate) 
        {
            _unitOfWork = unitOfWork;
            _exchangeRate = exchangeRate;            
        }

        [HttpGet]
        [Route("{isoCode}")]
        public async Task<IActionResult> GetRate(string isoCode) 
        {
            try
            {
                var response = new ResponseDTO<RatesDTO>();

                response = await _exchangeRate.ExchangeRateHandler(isoCode);

                if (response.Succeeded) return StatusCode(response.StatusCode, response.Data);
                
                return StatusCode(response.StatusCode, response.Errors);
            }
            catch (Exception err)
            {
                return StatusCode(500, err.Message);
            }            
        }

        [HttpPut]
        [Route("UpdateRates")]
        public async Task<IActionResult> UpdateRates()
        {
            try
            {
                var response = new ResponseDTO<RatesDTO>();

                response = await _exchangeRate.UpdateRates();

                _unitOfWork.Complete();

                if (response.Succeeded) 
                    return StatusCode(response.StatusCode, response.Message);

                return StatusCode(response.StatusCode, response.Errors);
            }
            catch (Exception err)
            {
                return StatusCode(500, err.Message);
            }
        }
    }
}
