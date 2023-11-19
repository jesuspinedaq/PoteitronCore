using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoteitronCore.Models
{
    internal class PhoneField : Field
    {
        public Boolean IncludContryCode { get; set; }

        public override string GetFormHtml()
        {
            var fieldCode = $"<FormMaskText name=\"{Name}\" mask=\"999 999 99 99\" label=\"{Label}\" onChange={{handleInputChange}} value={{values.phone}} error={{errors.{Name}}}/>";
            return "<Grid item xs={row}>" + fieldCode + "</Grid>";
        }

        public override string GetInitialValues()
        {
            return $"{Name}: \"\",";
        }
    }
}
