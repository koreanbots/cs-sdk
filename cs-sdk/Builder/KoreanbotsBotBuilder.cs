using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cs_sdk.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace cs_sdk.Builder
{
    public class KoreanbotsBotBuilder
    {
        public KoreanbotsBotModel BuildModel(string resjson)
        {
            var obj = JObject.Parse(resjson);
            obj = (JObject)obj["data"];
            var retmodel = obj.ToObject<KoreanbotsBotModel>(JsonSerializer.CreateDefault());
            
            foreach (string s in obj["category"])
            {
                retmodel.Categories.Add(Utils.StringToCateGoryEnum(s)); 
            }
            
            return retmodel;
        }
    }
}