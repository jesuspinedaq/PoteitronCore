using PoteitronCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PoteitronCore.Converters;
using Newtonsoft.Json;

namespace PoteitronCore.Handlers
{
    internal class FilterHandler
    {
        public string GenerateCode(string filePath, string template, string componentName)
        {
            var json = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), filePath));
            List<Field> items = JsonConvert.DeserializeObject<List<Field>>(json, new FieldConverter());

            var validation = new ValitaionRender();
            var initalValues = new InitialValues();

            var templateCode = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), template));

            templateCode = templateCode.Replace("#FORM#", Render(items));
            templateCode = templateCode.Replace("#VALIDATIONS#", validation.Render(items));
            templateCode = templateCode.Replace("#INITALVALUES#", initalValues.Render(items));
            templateCode = templateCode.Replace("#COMPONENTNAME#", string.IsNullOrEmpty(componentName) ? "ComponentGrid" : componentName);

            return templateCode;
        }

        public string Render(List<Field> items)
        {
            var formCode = "";
            var counter = 0;
            var buttonWasAdded = false; 
            foreach (var item in items)
            {
                counter++;
                if(counter % 3 == 0)
                {
                    if (!buttonWasAdded)
                    {
                        formCode += "<Grid item xs={2}><FormActionButton mr={2} text='Search' size='medium' onClick={refreshHandler} isSubmitting={false} type='search' /></Grid>";
                        buttonWasAdded = true;
                    }
                    else
                    {
                        formCode += "<Grid item xs={2}></Grid>";
                    }
                    
                }
                formCode += item.GetFormHtml() + "\n";

            }

            var validationFull = $@"<Form>
            <Grid container spacing={{5}}>{formCode}</Grid>
          </Form>";

            return validationFull;
        }
    }
}
