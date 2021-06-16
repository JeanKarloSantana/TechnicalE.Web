using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TechnicalE.Entities;
using TechnicalE.Interfaces.Generic;

namespace TechnicalE.Interfaces
{
    public interface ICurrencyRepository : IBaseRepository<Currency>
    {
        Task<int> GetCurrencyIdByIsoCode(string code);
    }
}
