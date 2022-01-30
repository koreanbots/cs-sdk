using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_sdk.Exceptions
{
    class KoreanBotsSearchException : Exception
    {
        public KoreanBotsSearchException(string message) : base(message){}
    }
}
