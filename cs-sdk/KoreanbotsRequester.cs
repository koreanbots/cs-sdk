using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using cs_sdk.Builder;
using cs_sdk.Exceptions;
using cs_sdk.Models;
using Newtonsoft.Json;
using RestSharp;

namespace cs_sdk
{
    public class KoreanBotsRequester
    {
        public string BaseUrl { get; set; } = Constants.APIV2;
        private string Token { get; set; }
        /// <summary>
        /// _b가 설정되지 않으면 기본 URL을 사용합니다. 
        /// </summary>
        /// <param name="_b">API BaseUrl</param>
        /// <param name="_t" > API Token</param>
        
        public KoreanBotsRequester(string _b= null, string _t = null)
        {
            if (_b != null) BaseUrl = _b;
            if (_t != null) Token = _t;
        }

        internal async Task<KoreanBotsBotModel> RequestBotByIdAsync(ulong id)
        {
            RestClient client = new RestClient(BaseUrl);
            RestRequest request = new RestRequest(string.Format(Constants.V2BOTBYID, id), Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);
            
            Utils.CheckHttpException(response);

            return KoreanBotsBotBuilder.BuildModel(response.Content);
        }

        public async Task<IReadOnlyCollection<KoreanBotsBotModel>> SearchBotAsync(string query, int page = 1)
        {
            RestClient client = new RestClient(BaseUrl);
            RestRequest request = new RestRequest(Constants.V2BOTSEARCH, Method.GET);
            request.AddQueryParameter("query", query);
            request.AddQueryParameter("page", page.ToString());
            IRestResponse response = await client.ExecuteAsync(request);
            
            Utils.CheckHttpException(response, true);

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return new ReadOnlyCollection<KoreanBotsBotModel>(new List<KoreanBotsBotModel>());
            }

            return KoreanBotsBotBuilder.BuildListModels(response.Content);
        }

        public async Task<IReadOnlyCollection<KoreanBotsBotModel>> GetBotsByNewAsync()
        {   RestClient client = new RestClient(BaseUrl);
            RestRequest request = new RestRequest(Constants.V2BOTLISTNEW, Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);

            Utils.CheckHttpException(response);
            
            return KoreanBotsBotBuilder.BuildListModels(response.Content);
        }

        public async Task<IReadOnlyCollection<KoreanBotsBotModel>> GetBotsByVotedAsync()
        {
            RestClient client = new RestClient(BaseUrl);
            RestRequest request = new RestRequest(Constants.V2BOTLISTVOTE, Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);

            Utils.CheckHttpException(response);

            return KoreanBotsBotBuilder.BuildListModels(response.Content);
        }

        public async Task<KoreanBotsUserVote> CheckVoteAsync(ulong botId, ulong userId)
        {
            RestClient client = new RestClient(BaseUrl);
            RestRequest request = new RestRequest(string.Format(Constants.V2USERVOTE, botId), Method.GET);
            request.AddHeader("Authorization", Token);
            request.AddQueryParameter("userID", userId.ToString());
            IRestResponse response = await client.ExecuteAsync(request);

            Utils.CheckHttpException(response);

            return KoreanBotsBotBuilder.BuildVoteModel(response.Content);
        }

        public async Task<KoreanBotsDefaultResponse> UpdateBotAsync(ulong botId, KoreanBotsUpdateModel data)
        {
            RestClient client = new RestClient(BaseUrl);
            RestRequest request = new RestRequest(string.Format(Constants.V2BOTUPDATE, botId), Method.POST);
            request.AddHeader("Authorization", Token);
            request.AddParameter("shards", data.Shards);
            request.AddParameter("servers", data.Servers);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

            IRestResponse response = await client.ExecuteAsync(request);

            Utils.CheckHttpException(response, ignoreTooMany:true);

            return KoreanBotsBuilder.BuildResponse(response.Content);
        }

        public async Task<KoreanBotsUserModel> RequestUserByIdAsync(ulong userid)
        {
            RestClient client = new RestClient(BaseUrl);
            RestRequest request = new RestRequest(string.Format(Constants.V2USERBYID, userid), Method.GET);

            IRestResponse response = await client.ExecuteAsync(request);

            Utils.CheckHttpException(response);

            return KoreanBotsUserBuilder.BuildModel(response.Content);
        }
    }
}
