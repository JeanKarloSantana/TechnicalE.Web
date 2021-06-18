using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalE.Domain.PurchaseTransactionManager;
using TechnicalE.Entities;
using TechnicalE.Entities.DTO;
using TechnicalE.Entities.Validators;

namespace TechnicalE.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IPurchaseTransactionManager _purchaseManager;
        public TransactionController(IPurchaseTransactionManager purchaseManager) 
        {
            _purchaseManager = purchaseManager;
        }

        [HttpPost]
        [Route("Purchase")]
        public async Task<IActionResult> Purchase(PurchaseDTO purchase) 
        {
            try
            {
                var validator = new PurchaseDTOValidator();
                
                ValidationResult all = validator.Validate(purchase);
                
                List<string> errors = new List<string>();
                    
                all.Errors.ForEach(t => errors.Add(t.ErrorMessage));
                
                if (!all.IsValid) return StatusCode(500, errors);                 

                ResponseDTO<PurchaseTransaction> response = await _purchaseManager.CurrencyPurchaseHandler(purchase);

                if (response.Succeeded)
                    return StatusCode(response.StatusCode, response.Message);

               return StatusCode(response.StatusCode, response.Errors);

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
