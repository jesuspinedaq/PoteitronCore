using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoteitronCore.Models
{
    internal class CommentField : Field
    {
        public override string GetFormHtml()
        {
            var fieldCode = "{/*" + Label + " */}";
                
            return fieldCode;
        }

        public override string GetInitialValues()
        {
            return $"";
        }
    }
}