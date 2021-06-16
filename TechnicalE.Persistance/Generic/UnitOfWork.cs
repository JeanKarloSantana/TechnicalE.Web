using System;
using System.Collections.Generic;
using System.Text;
using TechnicalE.DAL.SQL;
using TechnicalE.Interfaces;
using TechnicalE.Interfaces.Generic;

namespace TechnicalE.Persistance.Generic
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly TechnicalEvDbContext _dbContext;

        public UnitOfWork(TechnicalEvDbContext dbContext)
        {
            _dbContext = dbContext;

            Currencies = new CurrencyRepository(_dbContext);
            ExchangeRates = new ExchangeRateRepository(_dbContext);
            Users = new UserRepository(_dbContext);            
            Person = new PersonRepository(_dbContext);
            PurchaseTransactions = new PurchaseTransactionRepository(_dbContext);
        }

        public int Complete() => _dbContext.SaveChanges();
        public void Dispose() => _dbContext.Dispose();

        public ICurrencyRepository Currencies { get; set; }
        public IExchangeRateRepository ExchangeRates { get; set; }
        public IPurchaseTransactionRepository PurchaseTransactions { get; set; }
        public IPersonRepository Person { get; set; }
        public IUserRepository Users { get; set; }        
    }
}
