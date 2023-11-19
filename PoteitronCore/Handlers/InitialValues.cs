using PoteitronCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoteitronCore.Handlers
{
    internal class InitialValues
    {
        private string[] excludedTypesFrom = { "comment" };
        public string Render(List<Field> items)
        {
            var formCode = "";

            foreach (var item in items)
            {
                var val = item.GetInitialValues();
                if(!string.IsNullOrEmpty(val) && !excludedTypesFrom.Contains(item.Type))
                {
                    formCode += val + "\n";
                }
                
            }

            

            return formCode;
        }
    }
}
