using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalE.Entities.DTO;

namespace TechnicalE.Domain.ValidatorManager
{
    public interface IValidationManager
    {
        ValidationResult ValidatePurchaseDto(PurchaseDTO purchase);
    }
}
