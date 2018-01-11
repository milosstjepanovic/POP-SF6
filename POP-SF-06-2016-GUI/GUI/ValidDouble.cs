using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace POP_SF_06_2016_GUI.GUI
{
    class ValidDouble : ValidationRule
    {
        Regex myRegex = new Regex(@"-?\d+(?:\.\d+)?", RegexOptions.IgnoreCase);

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            
            String v = value as string;
            if (v != null && myRegex.Match(v).Success)
                return new ValidationResult(true, null);
            else
                return new ValidationResult(false, "Vrednost mora biti broj");

        }
    }
}
