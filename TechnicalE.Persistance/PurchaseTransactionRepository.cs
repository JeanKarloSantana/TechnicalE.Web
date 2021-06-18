using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalE.DAL.SQL;
using TechnicalE.Entities;
using TechnicalE.Entities.DTO;
using TechnicalE.Entities.Enums;
using TechnicalE.Interfaces;
using TechnicalE.Persistance.Generic;

namespace TechnicalE.Persistance
{
    public class PurchaseTransactionRepository : BaseRepository<PurchaseTransaction>, IPurchaseTransactionRepository
    {
        public TechnicalEvDbContext _context { get { return context; } }

        public PurchaseTransactionRepository(TechnicalEvDbContext dbContext) : base(dbContext)
        {
        }        

        public async Task<decimal> GetCurrentMonthPurchasedAmount(int idPerson, int idExchangeRate) => await _context.PurchaseTransaction
            .Where(t => t.IdPerson == idPerson
                && t.Date.Month == DateTime.UtcNow.Month
                && t.IdExchangeRate == idExchangeRate
                && t.IdTransactionType == (int)TransactionTypeEnum.CURRENCY_PURCHASE)
            .Select(a => a.PurchasedAmount)
            .SumAsync(s => s);

        public PurchaseTransaction FillTransactionRatesByExchangeRate(PurchaseTransaction transaction, ExchangeRate rate) 
        {
            transaction.IdExchangeRate = rate.Id;
            transaction.BuyRateLog = rate.Buy;
            transaction.SellRateLog = rate.Sell;

            return transaction;
        }

        public void AddTransaction(PurchaseTransaction transaction) 
        {
            transaction.IdTransactionType = (int)TransactionTypeEnum.CURRENCY_PURCHASE;
            transaction.Date = DateTime.UtcNow;
            Add(transaction);
        }
    }
}
