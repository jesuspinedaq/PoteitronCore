using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoteitronCore.Models
{
    internal class LabelField: Field
    {
        public string Content { get; set; }

        public override string GetFormHtml()
        {
            var code = $"<Typography variant=\"subtitle2\" gutterBottom>{Label}</Typography>";
            var code2 = $"<Typography variant=\"body2\" gutterBottom>{Content}</Typography>";
            return "<Grid item xs={row}>" + code + code2 + "</Grid>";
        }

        public override string GetInitialValues()
        {
            return "";
        }
    }
}
