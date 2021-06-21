using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalE.Entities.DTO;

namespace TechnicalE.Interfaces
{
    public interface IExchangeRateService
    {
        ResponseDTO<RatesDTO> GetProvinceBankApiRate(string url);       
        ResponseDTO<RatesDTO> GetApiRateForUpdate(string url);        
    }
}
