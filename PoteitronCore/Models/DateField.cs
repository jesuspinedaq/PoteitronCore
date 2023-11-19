using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoteitronCore.Models
{
    internal class DateField : Field
    {
        public override string GetFormHtml()
        {
            var fieldCode = $"<FormDatePicker name=\"{Name}\" " +
                $"label=\"{Label}\" " +
                $"value={{values.{Name}}} " +
                $"onChange={{handleInputChange}} " +
                $"error={{errors.{Name}}} /> ";
            return "<Grid item xs={row}>" + fieldCode + "</Grid>";
        }

        public override string GetInitialValues()
        {
            return $"{Name}: null,";
        }
    }
}
