using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using cs_sdk.Exceptions;
using cs_sdk.Models;

namespace cs_sdk
{
    public class KoreanBots
    {
        public string Token { get; set; }
        public string BaseUrl { get; set; }

        public KoreanBotsUser User { get; private set; }
        public KoreanBotsBot Bot { get; private set; }
        private KoreanBotsRequester requester;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_base"></param>
        /// <param name="_token"></param>
        public KoreanBots(string _base = null, string _token = null)
        {
            Token = _token;
            BaseUrl = _base;
            requester = new KoreanBotsRequester(BaseUrl, Token);

            User = new KoreanBotsUser(requester);
            Bot = new KoreanBotsBot(requester);
        }
    }
}
