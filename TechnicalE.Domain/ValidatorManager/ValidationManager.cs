using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalE.Domain.ValidatorManager;
using TechnicalE.Entities.DTO;
using TechnicalE.Entities.Validators;

namespace TechnicalE.Domain.ValidatosManager
{
    public class ValidationManager : IValidationManager
    {
        //This method is the data receive from a the request is valid
        public List<string> ValidatePurchaseDto(PurchaseDTO purchase) 
        {
            var validator = new PurchaseDTOValidator();

            ValidationResult validationResult = validator.Validate(purchase);

            List<string> errors = new List<string>();

            validationResult.Errors.ForEach(err => errors.Add(err.ErrorMessage));

            return errors;
        }
    }
}
