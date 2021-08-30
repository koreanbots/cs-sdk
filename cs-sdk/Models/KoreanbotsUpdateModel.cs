using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace cs_sdk.Models
{
    public class KoreanbotsUpdateModel
    {
        [JsonProperty("shards")]
        public int Shards { get; set; } = 0;
        [JsonProperty("servers")]
        public int Servers { get; set; } = 0;

        public KoreanbotsUpdateModel(int _shards = 0, int _servers = 0)
        {
            Shards = _shards;
            Servers = _servers;
        }

    }
}
