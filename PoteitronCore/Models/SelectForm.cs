using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoteitronCore.Models
{
    internal class SelectForm : Field
    {
        public string DataSource { get; set; }
        public override string GetFormHtml()
        {
            var fieldCode = $"<FormSelect name =\"{Name}\" label=\"{Label}\" value={{values.{Name}}} onChange={{handleInputChange}} options={{{DataSource}}} error={{errors.{Name}}} disable={{isSubmitting}} showSkeleton={{isLoading}} />";
            return "<Grid item xs={row}>" + fieldCode + "</Grid>";
        }

        public override string GetInitialValues()
        {
            return $"{Name}: -1,";
        }
    }
}
