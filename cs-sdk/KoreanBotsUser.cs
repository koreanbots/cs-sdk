using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cs_sdk.Models;

namespace cs_sdk
{
    public class KoreanBotsUser
    {
        private KoreanBotsRequester requester;
        public KoreanBotsUser(KoreanBotsRequester _req)
        {
            requester = _req;
        }

        public async Task<KoreanBotsUserModel> GetUserAsync(ulong id)
        {
            return await requester.RequestUserByIdAsync(id);
        }
    }
}
