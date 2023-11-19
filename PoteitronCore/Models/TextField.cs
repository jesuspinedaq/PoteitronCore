using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoteitronCore.Models
{
    internal class TextField : Field
    {
        public override string GetFormHtml()
        {
            var fieldCode = $"<FormTextArea name=\"{Name}\" label=\"{Label}\" value={{values.{Name}}} onChange={{handleInputChange}} error={{errors.{Name}}} placeholder=\"\" /> ";
            return "<Grid item xs={row}>" + fieldCode + "</Grid>";
        }

        public override string GetInitialValues()
        {
            return $"{Name}: \"\",";
        }
    }
}
