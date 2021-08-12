using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace cs_sdk
{
    public class KoreanbotsRequester
    {
        public string BaseUrl = Constants.APIV2;
        /// <summary>
        /// _b가 설정되지 않으면 기본 URL을 사용합니다.
        /// </summary>
        /// <param name="baseurl"></param>
        public KoreanbotsRequester(string _b= null)
        {
            if (_b != null) BaseUrl = _b;
        }

        public void CheckError(IRestResponse res)
        {
            
        }

        public async Task<string> RequestBotById(ulong id)
        {

        }
    }
}
