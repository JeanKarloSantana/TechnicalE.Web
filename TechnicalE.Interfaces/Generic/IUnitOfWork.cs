using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalE.Interfaces.Generic
{
    public interface IUnitOfWork
    {
        int Complete();
        void Dispose();

        public ICurrencyRepository Currencies { get; set; }
        public IExchangeRateRepository ExchangeRates { get; set; }       
        public IPersonRepository Person { get; set; }
        public IUserRepository Users { get; set; }
        public IPurchaseTransactionRepository PurchaseTransactions { get; set; }
    }
}
