using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalE.Interfaces.Services
{
    public interface IFormatNumbers
    {
        decimal FormatDecimalFourDigits(decimal number);
        decimal FormatDecimalTwoDigits(decimal number);
    }
}
