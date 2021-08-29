using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_sdk.Exceptions
{
    class KoreanbotsSearchException : Exception
    {
        public KoreanbotsSearchException(string message) : base(message){}
    }
}
