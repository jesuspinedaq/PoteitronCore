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
    internal class EmptyHandler
    {
        public string GenerateCode(string componentName)
        {
            var templateCode = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Template\\EmptyPage.txt"));

            templateCode = templateCode.Replace("#COMPONENTNAME#", string.IsNullOrEmpty(componentName) ? "EmptyPage" : componentName);

            return templateCode;
        }
    }
}
