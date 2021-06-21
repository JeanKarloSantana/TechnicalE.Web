using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using TechnicalE.Domain.PurchaseTransactionManager;
using TechnicalE.Domain.ValidatorManager;
using TechnicalE.Entities;
using TechnicalE.Entities.DTO;
using TechnicalE.Entities.Validators;
using TechnicalE.Interfaces.Generic;

namespace TechnicalE.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IPurchaseTransactionManager _purchaseManager;
        private readonly IValidationManager _validationManager;
        private readonly IUnitOfWork _unitOfWork;
        public TransactionController(IPurchaseTransactionManager purchaseManager, 
            IValidationManager validationManager,
            IUnitOfWork unitOfWork) 
        {
            _purchaseManager = purchaseManager;
            _validationManager = validationManager;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("Purchase")]
        public async Task<IActionResult> Purchase(PurchaseDTO purchase) 
        {
            try
            {
                List<string> errorsResult = _validationManager.ValidatePurchaseDto(purchase);
                
                if (errorsResult.Count > 0) return StatusCode(500, JsonSerializer.Serialize(errorsResult));

                ResponseDTO<PurchaseTransaction> response = await _purchaseManager.CurrencyPurchaseHandler(purchase);

                if (response.Succeeded)
                {
                    _unitOfWork.Complete();
                    return StatusCode(response.StatusCode, JsonSerializer.Serialize(response.Message));
                }

                return StatusCode(response.StatusCode, JsonSerializer.Serialize(response.Errors));

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
