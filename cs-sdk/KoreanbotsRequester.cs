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
using RestSharp;

namespace cs_sdk
{
    public class KoreanbotsRequester
    {
        public string BaseUrl { get; set; } = Constants.APIV2;

        /// <summary>
        /// _b가 설정되지 않으면 기본 URL을 사용합니다.
        /// </summary>
        /// <param name="baseurl"></param>
        public KoreanbotsRequester(string _b= null)
        {
            if (_b != null) BaseUrl = _b;
        }

        public async Task<KoreanbotsBotModel> RequestBotByIdAsync(ulong id)
        {
            RestClient client = new RestClient(BaseUrl);
            RestRequest request = new RestRequest(string.Format(Constants.V2BOTBYID, id), Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);
            
            Utils.CheckHttpException(response);

            KoreanbotsBotBuilder builder = new KoreanbotsBotBuilder();
            KoreanbotsBotModel model = builder.BuildModel(response.Content);
            return model;
        }

        public async Task<IReadOnlyCollection<KoreanbotsBotModel>> SearchBotByIdAsync(string query, int page = 1)
        {
            if (string.IsNullOrEmpty(query) || string.IsNullOrWhiteSpace(query))
            {
                throw new KoreanbotsSearchException("Query cannot be null or whitespace");
            }

            RestClient client = new RestClient(BaseUrl);
            RestRequest request = new RestRequest(Constants.V2BOTSEARCH, Method.GET);
            request.AddQueryParameter("query", query);
            request.AddQueryParameter("page", page.ToString());
            IRestResponse response = await client.ExecuteAsync(request);
            
            Utils.CheckHttpException(response, true);

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return new ReadOnlyCollection<KoreanbotsBotModel>(new List<KoreanbotsBotModel>());
            }

            KoreanbotsBotBuilder builder = new KoreanbotsBotBuilder();
            return builder.BuildListModels(response.Content);
        }

        public async Task<IReadOnlyCollection<KoreanbotsBotModel>> GetBotsByNewAsync()
        {   RestClient client = new RestClient(BaseUrl);
            RestRequest request = new RestRequest(Constants.V2BOTLISTNEW, Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);

            Utils.CheckHttpException(response);
            
            KoreanbotsBotBuilder builder = new KoreanbotsBotBuilder();
            return builder.BuildListModels(response.Content);
        }

        public async Task<IReadOnlyCollection<KoreanbotsBotModel>> GetBotsByVotedAsync()
        {
            RestClient client = new RestClient(BaseUrl);
            RestRequest request = new RestRequest(Constants.V2BOTLISTVOTE, Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);

            Utils.CheckHttpException(response);

            KoreanbotsBotBuilder builder = new KoreanbotsBotBuilder();
            return builder.BuildListModels(response.Content);
        }

        public async Task<KoreanbotsUserVote> CheckVoteAsync(ulong botId, ulong userId)
        {
            RestClient client = new RestClient(BaseUrl);
            RestRequest request = new RestRequest(string.Format(Constants.V2USERVOTE, botId), Method.GET);
            request.AddHeader("Authorization", Koreanbots.Token);
            request.AddQueryParameter("userID", userId.ToString());
            IRestResponse response = await client.ExecuteAsync(request);

            Utils.CheckHttpException(response);

            KoreanbotsBotBuilder builder = new KoreanbotsBotBuilder();
            return builder.BuildVoteModel(response.Content);
        }
    }
}
