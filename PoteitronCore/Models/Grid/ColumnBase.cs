using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoteitronCore.Models.Grid
{
    internal class ColumnBase
    {
        public string Name { get; set; }
        public string Label { get; set; }
        public bool Sort { get; set; }
        public string Type { get; set; }
        public string Format { get; set; }
        public string Callback { get; set; }

        protected virtual string GetBaseHtml()
        {
            return $" id: \"{Name}\", label: \"{Label}\", type: \"{Type}\", sort: {Sort.ToString().ToLower()},";
        }

        public virtual string GetHtml()
        {
            var innerCode = "";
            innerCode += GetBaseHtml();//$" id: \"{Name}\", label: \"{Label}\", type: \"{Type}\", sort: {Sort.ToString().ToLower()},";

            if (!string.IsNullOrEmpty(Format))
            {
                innerCode += $" format: \"{Format}\",";
            }

            if(Type == "custom")
            {
                innerCode += " callback: (row: any) => row.{name} }},";
            }

            return $"{{{innerCode}}},";
        }
    }

    
}
