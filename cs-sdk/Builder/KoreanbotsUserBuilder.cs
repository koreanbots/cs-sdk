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
    public class KoreanbotsUserBuilder
    {
        public KoreanbotsUserModel BuildModel(string resjson)
        {
            var obj = JObject.Parse(resjson);
            obj = (JObject)obj["data"];
            var retmodel = obj.ToObject<KoreanbotsUserModel>(JsonSerializer.CreateDefault());

            return retmodel;
        }
    }
}
