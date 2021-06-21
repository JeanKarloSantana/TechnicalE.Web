using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalE.Services.FormatNumbers;

namespace TechnicalE.NUnitTest.Services
{
    [TestFixture]
    public class FormatNumbersTest
    {
        [Test]
        public void FormatDecimalTwoDigits_WhenCalled_ReturnDecimalWithOnlyTwoDigitsAfterDot() 
        {
            FormatNumbers format = new FormatNumbers();

            decimal result = format.FormatDecimalTwoDigits((decimal)581.43561321);

            Assert.That(result, Is.EqualTo(581.44));
        }

        [Test]
        public void FormatDecimalFourDigits_WhenCalled_ReturnDecimalWithOnlyFourDigitsAfterDot()
        {
            FormatNumbers format = new FormatNumbers();

            decimal result = format.FormatDecimalFourDigits((decimal)75.85212365448);

            Assert.That(result, Is.EqualTo((decimal)75.8521));
        }
    }
}
