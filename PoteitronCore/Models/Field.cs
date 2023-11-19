using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoteitronCore.Models
{
    internal class Field
    {
        public string Name { get; set; }
        public string Label { get; set; }
        public string Type { get; set; }
        public int MaxLength { get; set; }
        public IEnumerable<Validation> Validations { get; set; }

        public Field()
        {
            Validations = new List<Validation>();
        }

        public virtual string GetFormHtml()
        {
            var optionalProps = "";
            optionalProps += this.MaxLength > 0 ? $"maxLength={{{MaxLength}}}" : "";

            var fieldCode =  $"<FormText name=\"{Name}\" label=\"{Label}\" value={{values.{Name}}} onChange={{handleInputChange}} error={{errors.{Name}}} showSkeleton={{isLoading}} {optionalProps} />";

            return "<Grid item xs={row}>" + fieldCode + "</Grid>";
        }

        public virtual string GetValidations()
        {
            if (!Validations.Any())
                return "";

            var validationCode = $"temp.{Name} = new Validator(fieldValues, \"{Name}\")";

            foreach (Validation validation in Validations)
            {
                if(validation.Type == "required")
                {
                    validationCode += validation.GetRequiredValidation();
                }else if(validation.Type == "maxLength")
                {
                    validationCode += validation.GetMaxLengthValidation();
                }else if(validation.Type == "requiredIf")
                {
                    validationCode += validation.GetRequiredIfValidation();
                }else if(validation.Type == "selectedOption")
                {
                    validationCode += validation.GetSelectedIsRequiredValidation();
                }
                else if (validation.Type == "email")
                {
                    validationCode += validation.GetEmailValidator();
                }
                //else if (validation.Type == "pattern")
                //{
                //    validationCode += validation.GetEmailValidator();
                //}
                else
                {
                    validationCode += $"/* {validation.Type} Validation not implemented*/";
                }
            }

            validationCode += ".toString();";

            return validationCode;
        }

        public virtual string GetInitialValues()
        {

            return $"{Name}: \"\",";
        }
    }
}
