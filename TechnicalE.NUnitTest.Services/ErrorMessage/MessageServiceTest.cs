using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalE.Entities;
using TechnicalE.Entities.DTO;
using TechnicalE.Services;

namespace TechnicalE.NUnitTest.Services.ErrorMessage
{
    [TestFixture]
    public class MessageServiceTest
    {
        private MessagesService _messages;
        private ResponseDTO<RatesDTO> _responseRates;
        private ResponseDTO<PurchaseTransaction> _responseTransaction;

        [SetUp]
        public void Setup()
        {
            _messages = new MessagesService();            
            _responseRates = new ResponseDTO<RatesDTO>();
            _responseTransaction = new ResponseDTO<PurchaseTransaction>();
            _responseTransaction.Data = new PurchaseTransaction();
        }

        [Test]
        public void UnableRetrieveRateDataFromApi_WhenCalled_ReturnMessageWithStatusCode() 
        {
            var result = _messages.UnableRetrieveRateDataFromApi(_responseRates, "NotFound");

            Assert.That(result, Is.TypeOf<ResponseDTO<RatesDTO>>());
            Assert.That(result.StatusCode, Is.EqualTo(500));
            Assert.That(result.Succeeded, Is.Not.True);
            Assert.That(result.Errors, Is.Not.Empty);
        }

        [Test]
        public void InvalidCurrencyIsoCode_WhenCalled_ReturnMessageWithStatusCode()
        {
            var result = _messages.InvalidCurrencyIsoCode(_responseRates, "NotFound");

            Assert.That(result, Is.TypeOf<ResponseDTO<RatesDTO>>());
            Assert.That(result.StatusCode, Is.EqualTo(400));
            Assert.That(result.Succeeded, Is.Not.True);
            Assert.That(result.Errors, Is.Not.Empty);
        }

        [Test]
        public void UpdateCurrenciesRates_WhenCalled_ReturnMessageWithStatusCode()
        {
            var result = _messages.UpdateCurrenciesRates(_responseRates);

            Assert.That(result, Is.TypeOf<ResponseDTO<RatesDTO>>());
            Assert.That(result.StatusCode, Is.EqualTo(200));            
            Assert.That(result.Message, Is.Not.Null);            
        }

        [Test]
        public void PurchaseTransaction_WhenCalled_ReturnMessageWithStatusCode()
        {
            var result = _messages.PurchaseTransaction(_responseTransaction, "USD");

            Assert.That(result, Is.TypeOf<ResponseDTO<PurchaseTransaction>>());
            Assert.That(result.StatusCode, Is.EqualTo(201));
            Assert.That(result.Message, Is.Not.Null);
        }

        [Test]
        public void PurchaseLimitReached_WhenCalled_ReturnMessageWithStatusCode()
        {
            var result = _messages.PurchaseLimitReached(_responseTransaction);

            Assert.That(result, Is.TypeOf<ResponseDTO<PurchaseTransaction>>());
            Assert.That(result.StatusCode, Is.EqualTo(500));
            Assert.That(result.Succeeded, Is.Not.True);
            Assert.That(result.Errors, Is.Not.Empty);
        }
        [Test]
        public void CurrencyNotAvailable_WhenCalled_ReturnMessageWithStatusCode()
        {
            var result = _messages.CurrencyNotAvailable(_responseTransaction, "EUR");

            Assert.That(result, Is.TypeOf<ResponseDTO<PurchaseTransaction>>());
            Assert.That(result.StatusCode, Is.EqualTo(400));
            Assert.That(result.Succeeded, Is.Not.True);
            Assert.That(result.Errors, Is.Not.Empty);
        }

    }
}
