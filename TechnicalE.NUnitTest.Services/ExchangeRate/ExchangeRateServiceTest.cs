using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalE.Domain.Business;
using TechnicalE.Entities.DTO;
using TechnicalE.Entities.Enums;
using TechnicalE.Services;

namespace TechnicalE.NUnitTest.Services.ExchangeRate
{
    [TestFixture]
    public class ExchangeRateServiceTest
    {
        private ExchangeRateService _exchangeRateService;
        private RatesDTO _rateGetCurrancyRate;

        [SetUp]
        public void Setup()
        {
            _exchangeRateService = new ExchangeRateService();            
        }

        [Test]
        public void FormatProvinceBankResponse_WhenCalled_TakeApiJsonResultAndReturnRatesDTOFilled() 
        {
            var valueList = new List<string>();
            valueList.Add("75.5645");
            valueList.Add("100.55");
            valueList.Add("Actualizado el 15/5/2021 15:00");

            var result = new RatesDTO();
            
            result = _exchangeRateService.FormatProvinceBankResponse(valueList, result);

            Assert.That(result.Buy, Is.EqualTo((decimal)75.5645));
            Assert.That(result.Sell, Is.EqualTo((decimal)100.55));
            Assert.That(result.Updated, Is.EqualTo(Convert.ToDateTime("2021-05-15T15:00:00")));
        }        
    }
}
