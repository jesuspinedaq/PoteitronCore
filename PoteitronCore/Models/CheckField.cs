using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoteitronCore.Models
{
    internal class CheckField: Field
    {
        public override string GetFormHtml()
        {
            

            var fieldCode = $"<FormCheckBox " +
                $"label = \"{Label}\" " +
                $"name = \"{Name}\" " +
                $"value ={{ values.{Name}}} " +
                $"onChange ={{handleInputChange}} /> ";
            return "<Grid item xs={row}>" + fieldCode + "</Grid>";
        }

        public override string GetInitialValues()
        {
            return $"{Name}: false,";
        }
    }
}
