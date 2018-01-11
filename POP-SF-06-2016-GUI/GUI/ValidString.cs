using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace POP_SF_06_2016_GUI.GUI
{
    class ValidString : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string unetiString = (string)value;

            if (string.IsNullOrEmpty(unetiString))
            {
                return new ValidationResult(false, "Morate popuniti ovo polje!");
            }
            return new ValidationResult(true, null);
        }
    }
}
