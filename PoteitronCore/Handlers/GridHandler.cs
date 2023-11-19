using Newtonsoft.Json;
using PoteitronCore.Converters;
using PoteitronCore.Models;
using PoteitronCore.Models.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoteitronCore.Handlers
{
    internal class GridHandler
    {
        public string GenerateCode(string filePath, string template, string componentName)
        {
            var json = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), filePath));
            List<ColumnBase> items = JsonConvert.DeserializeObject<List<ColumnBase>>(json, new ColumnConverter());

            var templateCode = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), template));

            templateCode = templateCode.Replace("#COLUMN#", GetColumnDefinition(items));
            templateCode = templateCode.Replace("#COMPONENTNAME#", string.IsNullOrEmpty(componentName) ? "ComponentGrid" : componentName);

            return templateCode;
        }

        private string GetColumnDefinition(List<ColumnBase>? items)
        {
            var code = "";
            foreach (var item in items)
            {
                code += item.GetHtml();
            }

            //

            return $"const getColumns = (): ColumnType[] => [{code}];";
        }
    }
}
