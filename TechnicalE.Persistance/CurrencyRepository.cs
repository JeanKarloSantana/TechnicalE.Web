using System;
using System.Collections.Generic;
using System.Text;
using TechnicalE.DAL.SQL;
using TechnicalE.Entities;
using TechnicalE.Interfaces;
using TechnicalE.Persistance.Generic;

namespace TechnicalE.Persistance
{
    public class CurrencyRepository : BaseRepository<Currency>, ICurrencyRepository
    {
        public TechnicalEvDbContext _context { get { return context; } }

        public CurrencyRepository(TechnicalEvDbContext dbContext) : base(dbContext)
        {
        }     
    }
}
