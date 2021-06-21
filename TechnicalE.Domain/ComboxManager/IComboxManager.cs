using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalE.Entities.DTO;

namespace TechnicalE.Domain.ComboxManager
{
    public interface IComboxManager
    {
        Task<List<Combox>> CurrencyCodeCombox();
    }
}
