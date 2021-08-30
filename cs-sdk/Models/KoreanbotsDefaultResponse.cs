using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace cs_sdk.Models
{
    public class KoreanbotsDefaultResponse
    {
        [JsonProperty("code")]
        public int Code { get; }
        [JsonProperty("message")]
        public string Message { get;}
        public bool IsSuccessful { get; } = true;
        public KoreanbotsDefaultResponse(int _code = 200, string _message = null)
        {
            Code = _code;
            Message = _message;
            IsSuccessful = Code == 200;
        }
    }
}
