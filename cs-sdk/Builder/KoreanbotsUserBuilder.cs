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
    public class KoreanBotsUserBuilder
    {
        public static KoreanBotsUserModel BuildModel(string resjson)
        {
            var obj = JObject.Parse(resjson);
            obj = (JObject)obj["data"];
            JsonSerializer se = JsonSerializer.CreateDefault();
            se.NullValueHandling = NullValueHandling.Ignore;
            var retmodel = obj.ToObject<KoreanBotsUserModel>(se);
            
            return retmodel;
        }
    }
}
