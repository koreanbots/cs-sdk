using System;
using System.Net;
using cs_sdk.Builder;
using cs_sdk.Models;
using Newtonsoft.Json;
using NUnit.Framework;

namespace cs_sdk_tests
{
    public class ParseTest
    {
        private string BotJson;
        private KoreanBotsBotModel kbm;
        private KoreanBotsUserModel kum;

        [SetUp]
        public void Setup()
        {
            var wc = new WebClient();
            kbm = new KoreanBotsBotModel();
            kum = new KoreanBotsUserModel();
            BotJson = wc.DownloadString(
                "https://cdn.discordapp.com/attachments/745844596176715806/860681532535996466/test.json");
        }

        [Test]
        public void SerializeTest()
        {
            Console.WriteLine("Serializing KBM");
            JsonConvert.SerializeObject(kbm);
            Console.WriteLine("Serializing KUM");
            JsonConvert.SerializeObject(kum);
            Assert.Pass();
        }

        [Test]
        public void DeserializeTest()
        {
            Console.WriteLine("Deserializing Json to KBM");
            kbm = KoreanBotsBotBuilder.BuildModel(BotJson);
            Console.WriteLine(JsonConvert.SerializeObject(kbm));
            //Console.WriteLine("Deserializing Json KUM");
            //JsonConvert.DeserializeObject(kum);
            Assert.Pass();
        }
    }
}