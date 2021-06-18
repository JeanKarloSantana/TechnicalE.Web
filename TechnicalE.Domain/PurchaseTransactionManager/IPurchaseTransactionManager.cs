using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalE.Entities;
using TechnicalE.Entities.DTO;

namespace TechnicalE.Domain.PurchaseTransactionManager
{
    public interface IPurchaseTransactionManager
    {
        Task<ResponseDTO<PurchaseTransaction>> CurrencyPurchaseHandler(PurchaseDTO purchase);
    }
}
