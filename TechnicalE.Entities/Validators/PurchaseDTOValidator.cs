using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalE.Entities.DTO;

namespace TechnicalE.Entities.Validators
{
    public class PurchaseDTOValidator : AbstractValidator<PurchaseDTO>  
    {
        public PurchaseDTOValidator() 
        {
            RuleFor(x => x)
                .Must(y => y.IdUser > 0)
                .WithMessage("Your request does not have an Id user, Please provide an Id User");

            RuleFor(x => x.Code).NotNull()
                .WithMessage("Your request does not have a currency Code, Please provide a currency code");

            RuleFor(x => x)
                .Must(y => y.Amount > 0)
                .WithMessage("Your request does not have a purchase amount or the amount is 0, Please provide a Purchase Amount greater than 0");
        }
    }
}
