using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using cs_sdk.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace cs_sdk.Builder
{
    public class KoreanBotsBotBuilder
    {
        public static KoreanBotsBotModel BuildModel(string resjson)
        {
            var js = JsonSerializer.CreateDefault();
            js.NullValueHandling = NullValueHandling.Ignore;
            var obj = JObject.Parse(resjson);
            obj = (JObject)obj["data"];
            var retmodel = obj.ToObject<KoreanBotsBotModel>(js);

            foreach (string s in obj["category"]) retmodel.Categories.Add(Utils.StringToCategoryEnum(s));

            return retmodel;
        }

        public static IReadOnlyCollection<KoreanBotsBotModel> BuildListModels(string resjson)
        {
            var js = JsonSerializer.CreateDefault();
            js.NullValueHandling = NullValueHandling.Ignore;
            var obj = JObject.Parse(resjson);
            var arr = (JArray)obj["data"]["data"];
            List<KoreanBotsBotModel> listm;
            listm = arr.ToObject<List<KoreanBotsBotModel>>(js);

            var models = new ReadOnlyCollection<KoreanBotsBotModel>(listm);
            return models;
        }

        public static KoreanBotsUserVote BuildVoteModel(string resjson)
        {
            var js = JsonSerializer.CreateDefault();
            js.NullValueHandling = NullValueHandling.Ignore;
            var obj = JObject.Parse(resjson);
            obj = (JObject)obj["data"];
            var retmodel = new KoreanBotsUserVote();
            retmodel.Voted = obj["voted"].Value<bool>();
            JToken dat;
            if (obj.TryGetValue("lastVote", out dat) && dat.Type != JTokenType.Null)
                retmodel.LastVotedTime = new DateTime(1970, 1, 1).AddMilliseconds(dat.Value<long>());
            return retmodel;
        }
    }
}