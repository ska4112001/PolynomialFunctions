using System;
using System.Collections.Generic;
using System.Text;

namespace Polynomial.Infrastructure.Shared.Util
{
    public  class Util
    {
        public static bool IsNumeric(string text)
        {
            double doubleValue;
            return double.TryParse(text, out doubleValue);
        }
    }
}
