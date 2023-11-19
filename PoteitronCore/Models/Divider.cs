using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoteitronCore.Models
{
    internal class Divider:Field
    {
        public override string GetFormHtml()
        {
            return @"<Grid item xs={12}><Divider orientation='horizontal' flexItem></Divider></Grid>";
        }
        public override string GetInitialValues()
        {
            return "";
        }
    }
}
