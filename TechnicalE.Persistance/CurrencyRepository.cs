using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<int> GetCurrencyIdByIsoCode(string IsoCode) => await context.Currency
            .Where(c => c.Country.ISOCode == IsoCode.ToUpper())
            .Select(c => c.Id)
            .FirstOrDefaultAsync();
        
        public async Task<int> GetCurrencyIdByCode(string code) => await context.Currency
            .Where(c => c.Code == code.ToUpper())
            .Select(c => c.Id)
            .FirstOrDefaultAsync();

        public async Task<string> GetCurrencyNameByCode(string code) => await context.Currency
            .Where(c => c.Code == code.ToUpper())
            .Select(c => c.Name)
            .FirstOrDefaultAsync();
    }
}
