using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoteitronCore.Models.Grid
{
    internal class ColumnCustom: ColumnBase
    {
        public string CustomType { get; set; }

        public override string GetHtml()
        {
            var code = GetBaseHtml();

            if(CustomType == "action")
            {
                code += "callback: (row: any) => (<Stack direction='row'><GridActionButton type='enable' tooltip='' onClick={() => {}} /></Stack>),";
            }
            else
            {
                code += $"callback: (row: any) => row.{Name},";
            }

            return $"{{{code}}},";
        }
    }
}
