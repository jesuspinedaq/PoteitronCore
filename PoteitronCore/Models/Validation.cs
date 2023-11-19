using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoteitronCore.Models
{
    internal class Validation
    {
        public string Type { get; set; }
        public string Message { get; set; }
        public string Value { get; set; }
        public string Condition { get; set; }
        public string GetRequiredValidation()
        {
            return $".isRequired(\"{Message}\")";
        }

        public string GetMaxLengthValidation()
        {
            return $".maxLength({Value}, \"{Message}\")";
        }

        public string GetSelectedIsRequiredValidation()
        {
            return $".selectedOption(\"\", \"{Message}\")";
        }

        public string GetRequiredIfValidation()
        {
            return $".validateIf({Condition})";
        }

        public string GetEmailValidator()
        {
            return $".emailFormat(\"{Message}\")";
        }
    }
}
