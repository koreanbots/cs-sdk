using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_sdk.Models
{
    [Obsolete]
    public class KoreanbotsSearchResponse
    {
        public int TotalPage = 1;
        public IReadOnlyList<KoreanbotsBotModel> Result = null;
    }
}
