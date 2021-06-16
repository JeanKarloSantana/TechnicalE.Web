using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalE.Interfaces.Services;

namespace TechnicalE.Services.FormatNumbers
{
    public class FormatNumbers : IFormatNumbers
    {
        public decimal FormatDecimalFourDigits(decimal number)
        {
            string format = String.Format("{0:0.0000}", number).ToString();
            return decimal.Parse(format);
        }

        public decimal FormatDecimalTwoDigits(decimal number)
        {
            string format = String.Format("{0:0.00}", number).ToString();
            return Convert.ToDecimal(format);
        }
    }
}
