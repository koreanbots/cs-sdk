﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cs_sdk.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace cs_sdk.Builder
{
    class KoreanBotsBuilder
    {
        public static KoreanBotsDefaultResponse BuildResponse(string resjson)
        {
            var js = JsonSerializer.CreateDefault();
            js.NullValueHandling = NullValueHandling.Ignore;
            var obj = JObject.Parse(resjson);
            int code = obj["code"].Value<int>();
            string message = obj["message"].Value<string>();
            var retmodel = new KoreanBotsDefaultResponse(code, message);
            return retmodel;
        }
    }
}
