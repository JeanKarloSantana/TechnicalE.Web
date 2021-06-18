using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TechnicalE.Entities;
using TechnicalE.Entities.DTO;
using TechnicalE.Interfaces.Generic;

namespace TechnicalE.Interfaces
{
    public interface IPurchaseTransactionRepository : IBaseRepository<PurchaseTransaction>
    {        
        Task<decimal> GetCurrentMonthPurchasedAmount(int idPerson, int idExchangeRate);
        PurchaseTransaction FillTransactionRatesByExchangeRate(PurchaseTransaction transaction, ExchangeRate rate);
        void AddTransaction(PurchaseTransaction transaction);
    }
}
