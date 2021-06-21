using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalE.DAL.SQL;
using TechnicalE.Entities.DTO;

namespace TechnicalE.Domain.ComboxManager
{
    public class ComboxManager: IComboxManager
    {
        private readonly TechnicalEvDbContext _context;

        public ComboxManager(TechnicalEvDbContext context)
        {
            _context = context;
        }

        public async Task<List<Combox>> CurrencyCodeCombox() => await _context.Currency
            .Select(x => new Combox { Id = x.Id, Name = x.Code })
            .ToListAsync();
    }
}
