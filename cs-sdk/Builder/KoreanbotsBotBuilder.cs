using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using cs_sdk.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace cs_sdk.Builder
{
    public class KoreanbotsBotBuilder
    {
        public KoreanbotsBotModel BuildModel(string resjson)
        {
            var js = JsonSerializer.CreateDefault();
            js.NullValueHandling = NullValueHandling.Ignore;
            var obj = JObject.Parse(resjson);
            obj = (JObject)obj["data"];
            var retmodel = obj.ToObject<KoreanbotsBotModel>(js);

            foreach (string s in obj["category"]) retmodel.Categories.Add(Utils.StringToCategoryEnum(s));

            return retmodel;
        }

        public IReadOnlyCollection<KoreanbotsBotModel> BuildListModels(string resjson)
        {
            var js = JsonSerializer.CreateDefault();
            js.NullValueHandling = NullValueHandling.Ignore;
            var obj = JObject.Parse(resjson);
            var arr = (JArray)obj["data"]["data"];
            List<KoreanbotsBotModel> listm;
            listm = arr.ToObject<List<KoreanbotsBotModel>>(js);

            var models = new ReadOnlyCollection<KoreanbotsBotModel>(listm);
            return models;
        }

        public KoreanbotsUserVote BuildVoteModel(string resjson)
        {
            var js = JsonSerializer.CreateDefault();
            js.NullValueHandling = NullValueHandling.Ignore;
            var obj = JObject.Parse(resjson);
            obj = (JObject)obj["data"];
            var retmodel = new KoreanbotsUserVote();
            retmodel.Voted = obj["voted"].Value<bool>();
            JToken dat;
            if (obj.TryGetValue("lastVote", out dat) && dat.Type != JTokenType.Null)
                retmodel.LastVotedTime = new DateTime(1970, 1, 1).AddMilliseconds(dat.Value<long>());
            return retmodel;
        }
    }
}