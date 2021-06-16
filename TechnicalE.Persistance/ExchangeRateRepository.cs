using System;
using System.Collections.Generic;
using System.Text;
using TechnicalE.DAL.SQL;
using TechnicalE.Entities;
using TechnicalE.Interfaces;
using TechnicalE.Persistance.Generic;

namespace TechnicalE.Persistance
{
    public class ExchangeRateRepository : BaseRepository<ExchangeRate>, IExchangeRateRepository
    {
        public TechnicalEvDbContext _context { get { return context; } }

        public ExchangeRateRepository(TechnicalEvDbContext dbContext) : base(dbContext)
        {
        }
    }
}
