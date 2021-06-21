using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalE.Services.ExchangeRate;

namespace TechnicalE.NUnitTest.Services
{
    [TestFixture]
    public class RateConversionServiceTest
    {
        private RateConversionService _rateConversion;

        [SetUp]
        public void Setup()
        {
            _rateConversion = new RateConversionService();
        }

        [Test]
        [TestCase(100, 4500, 45)]
        public void BuyCurrency_WhenCalled_ReturnTheAmountBuyingInOtherCurrency(decimal sellRate, decimal amount, decimal expectedResult) 
        {
            var result = _rateConversion.BuyCurrency(sellRate, amount);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(94, 60, 5640)]
        public void SellCurrency_WhenCalled_ReturnTheAmountFromCurrencyToARS(decimal buyRate, decimal amount, decimal expectedResult)
        {
            var result = _rateConversion.SellCurrency(buyRate, amount);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
