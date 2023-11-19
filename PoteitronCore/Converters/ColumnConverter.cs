using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PoteitronCore.Models.Grid;

namespace PoteitronCore.Converters
{
    internal class ColumnConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(ColumnBase).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader,
            Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);

            var type = (string)jo["type"];

            ColumnBase column;

            if(type == "custom")
            {
                column = new ColumnCustom();
            }
            else
            {
                column = new ColumnBase();
            }

            serializer.Populate(jo.CreateReader(), column);

            return column;

        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer,
            object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
