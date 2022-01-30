using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cs_sdk.Exceptions;
using cs_sdk.Models;

namespace cs_sdk
{
    public class KoreanBotsBot
    {
        private KoreanBotsRequester requester;
        public KoreanBotsBot(KoreanBotsRequester _req)
        {
            requester = _req;
        }

        public async Task<KoreanBotsBotModel> GetBotAsync(ulong id)
        {
            return await requester.RequestBotByIdAsync(id);
        }

        public async Task<IReadOnlyCollection<KoreanBotsBotModel>> SearchBotAsync(string query, int page = 1)
        {
            if (1 > page)
            {
                throw new ArgumentException("Page cannot be less than 1");
            }
            if (string.IsNullOrEmpty(query) || string.IsNullOrWhiteSpace(query))
            {
                throw new KoreanBotsSearchException("Query cannot be null or whitespace");
            }

            return await requester.SearchBotAsync(query, page);
        }

        public async Task<IReadOnlyCollection<KoreanBotsBotModel>> GetNewestBotsAsync()
        {
            return await requester.GetBotsByNewAsync();
        }

        public async Task<IReadOnlyCollection<KoreanBotsBotModel>> GetBotsByVotedAsync()
        {
            return await requester.GetBotsByVotedAsync();
        }

        public async Task<KoreanBotsUserVote> CheckUserVoted(ulong botId, ulong userId)
        {
            return await requester.CheckVoteAsync(botId, userId);
        }

        public async Task<KoreanBotsDefaultResponse> UpdateBotAsync(ulong botId,KoreanBotsUpdateModel model)
        {
            return await requester.UpdateBotAsync(botId, model);
        }
    }
}
