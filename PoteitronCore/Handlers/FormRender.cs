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
    internal class FormRender
    {
        public string GenerateCode(string filePath, string template, string componentName)
        {
            var json = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), filePath));
            List<Field> items = JsonConvert.DeserializeObject<List<Field>>(json, new FieldConverter());


            var form = new FormRender();
            var validation = new ValitaionRender();
            var initalValues = new InitialValues();

            var templateCode = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), template));

            templateCode = templateCode.Replace("#FORM#", form.Render(items));
            templateCode = templateCode.Replace("#VALIDATIONS#", validation.Render(items));
            templateCode = templateCode.Replace("#INITALVALUES#", initalValues.Render(items));
            templateCode = templateCode.Replace("#COMPONENTNAME#", string.IsNullOrEmpty(componentName) ? "ComponentGrid" : componentName);

            return templateCode;
        }

        public string Render(List<Field> items)
        {
            var formCode = "";

            foreach (var item in items)
            {
                formCode += item.GetFormHtml() + "\n";
            }

            var validationFull = $@"<Form>
            <Grid container spacing={{5}}>{formCode}
                <Grid item xs={{12}}>
                <Stack direction='row' spacing ={{2}} justifyContent = 'center' alignItems = 'center' >
                  <FormCancelButton onClick ={{cancelHandler}} isSubmitting ={{isSubmitting}} />
                  <FormSaveButton onClick ={{saveHandler}} isSubmitting={{isSubmitting}} />
                </Stack>
              </Grid>
            </Grid>
          </Form>";

            return validationFull;
        }
    }
}
