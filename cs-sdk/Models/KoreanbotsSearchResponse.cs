using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_sdk.Models
{
    public class KoreanbotsGenericResponse
    {
        public int ResponseCode = 200;
        public int TotalPage = 1;
        public IReadOnlyList<KoreanbotsBotModel> Result = null;
    }
}
