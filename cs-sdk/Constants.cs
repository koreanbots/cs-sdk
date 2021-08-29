using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_sdk
{
    class Constants
    {
        public static string APIV2 = "https://koreanbots.dev/api/v2";
        public static string V2BOTBYID = "/bots/{0}";
        public static string V2BOTSEARCH = "/search/bots";
        public static string V2BOTLISTVOTE = "/list/bots/votes";
        public static string V2BOTLISTNEW = "/list/bots/new";
        public static string V2USERVOTE = "/bots/{0}/vote";
    }
}
