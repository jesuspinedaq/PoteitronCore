using PoteitronCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoteitronCore.Handlers
{
    internal class ValitaionRender
    {
        public string Render(List<Field> items)
        {
            var validationsCode = "";

            foreach (var item in items)
            {
                validationsCode += item.GetValidations() + "\n\n";
            }

            var validationFull = $@"const validate = (fieldValues = values) => {{
            let temp: Record<string, string> = {{ ...errors }};

            {validationsCode}

            setErrors({{
                ...temp,
            }});

            if (fieldValues === values)
                return Object.values(temp).every((x) => x === """");
            }};";

            return validationFull;
        }
    }
}
