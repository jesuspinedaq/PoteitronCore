using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PoteitronCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoteitronCore.Converters
{
    internal class FieldConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(Field).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader,
            Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);

            var type = (string)jo["type"];

            Field item;
            if (type == "phone")
            {
                item = new PhoneField();
            }
            else if(type == "select")
            {
                item = new SelectForm();
            }
            else if (type == "email")
            {
                item = new EmailField();
            }
            else if (type == "label")
            {
                item = new LabelField();
            }
            else if (type == "text")
            {
                item = new TextField();
            }
            else if (type == "number")
            {
                item = new NumericField();
            }
            else if (type == "divider")
            {
                item = new Divider();
            }
            else if(type == "check")
            {
                item = new CheckField();
            }
            else if (type == "date")
            {
                item = new DateField();
            }
            else if (type == "comment")
            {
                item = new CommentField();
            }
            else
            {
                item = new Field();
            }

            serializer.Populate(jo.CreateReader(), item);

            return item;
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
