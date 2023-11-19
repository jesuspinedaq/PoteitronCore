using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoteitronCore.Models
{
    internal class NumericField : Field
    {
        //public int MaxLength { get; set; }
        public string Suffix { get; set; }
        public string Prefix { get; set; }
        public int DecimalScale { get; set; }
        public override string GetFormHtml()
        {
            var optionalProps = "";
            optionalProps += this.MaxLength > 0 ? $"maxLength={{{MaxLength}}}" : "";
            optionalProps += string.IsNullOrEmpty(optionalProps) ? "" : " ";
            optionalProps += string.IsNullOrEmpty(Suffix) ? "" : $"suffix={{'{Suffix}'}}";
            optionalProps += string.IsNullOrEmpty(optionalProps) ? "" : " ";
            optionalProps += string.IsNullOrEmpty(Prefix) ? "" : $"prefix={{'{Prefix}'}}";
            optionalProps += string.IsNullOrEmpty(optionalProps) ? "" : " ";
            optionalProps += DecimalScale > 0 ? $"decimalScale={{{DecimalScale}}}" : "";

            var fieldCode = $"<FormNumeric name=\"{Name}\" " +
                $"label=\"{Label}\" " +
                $"value={{values.{Name}}} " +
                $"onChange={{handleInputChange}} " +
                $" {optionalProps}" +
                $"error={{errors.{Name}}} " +
                $"placeholder=\"\" /> ";
            return "<Grid item xs={row}>" + fieldCode + "</Grid>";
        }

        public override string GetInitialValues()
        {
            return $"{Name}: 0,";
        }
    }
}
