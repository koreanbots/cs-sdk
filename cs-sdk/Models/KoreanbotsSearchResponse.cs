using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_sdk.Models
{
    [Obsolete]
    public class KoreanBotsSearchResponse
    {
        public int TotalPage = 1;
        public IReadOnlyList<KoreanBotsBotModel> Result = null;
    }
}
