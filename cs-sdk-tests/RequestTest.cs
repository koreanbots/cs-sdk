using cs_sdk;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;
using cs_sdk.Models;

namespace cs_sdk_tests
{
    public class RequestTest
    {
        private KoreanBots req;
        [SetUp]
        public void Setup()
        {
            req = new KoreanBots();
        }

        [Test]
        public async Task BotByIdRequestTest()
        {
            Console.WriteLine("Requesting bot using id 387548561816027138");
            var model = await req.Bot.GetBotAsync(387548561816027138);
            Console.WriteLine(model.Owners.FirstOrDefault().Flags.ToString());
            Console.WriteLine(JsonConvert.SerializeObject(model));
            Assert.Pass();
        }

        [Test]
        public async Task BotSearchRequestTest()
        {
            Console.WriteLine("Searching bots using query wonder");
            var model = await req.Bot.SearchBotAsync("KawahoriAria");
            if (model.Count == 0)
            {
                Assert.Fail();
                return;
            }
            Console.WriteLine(JsonConvert.SerializeObject(model));
            Assert.Pass();
        }

        [Test]
        public async Task BotSearchRequestTestEmptyQuery()
        {
            bool a = false, b = false, c = false;
            Console.WriteLine("Searching bots using empty query");
            try
            {
                await req.Bot.SearchBotAsync("");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                a = true;
            }
            try
            {
                await req.Bot.SearchBotAsync(null);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                b = true;
            }
            try
            {
                await req.Bot.SearchBotAsync("  ");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                c = true;
            }

            if (a && b && c)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public async Task BotSearchRequestTestBadRequest()
        {
            Console.WriteLine("Searching bots with badrequest");
            try
            {
                await req.Bot.SearchBotAsync("1");
                Assert.Fail();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                if (!e.Message.Contains("Bad"))
                {
                    Assert.Fail();
                }
                else
                {
                    Assert.Pass();
                }
            }
            
        }

        [Test]
        public async Task BotSearchRequestTestNotFound()
        {
            Console.WriteLine("Searching bots with notfound");

            var d = await req.Bot.SearchBotAsync("대충없는거");
            Console.WriteLine($"Count: {d.Count}(ok:0)");
            if (d.Count != 0)
            {
                Assert.Fail();
            }
            else
            {
                Assert.Pass();
            }
        }

        [Test]
        public async Task BotNewListTest()
        {
            Console.WriteLine("Requesting Bots by new");
            var d = await req.Bot.GetNewestBotsAsync();
            if (d.Count == 0)
            {
                Assert.Fail();
                return;
            }
            Console.WriteLine(JsonConvert.SerializeObject(d));
            Assert.Pass();
        }

        [Test]
        public async Task BotVotedListTest()
        {
            Console.WriteLine("Requesting Bots by voted");
            var d = await req.Bot.GetBotsByVotedAsync();
            if (d.Count == 0)
            {
                Assert.Fail();
                return;
            }
            Console.WriteLine(JsonConvert.SerializeObject(d));
            Assert.Pass();
        }

        public string Token =
            "TOKEN HERE";
        [Test]
        public async Task BotCheckVoteTest()
        {
            req.Token = Token;
            Console.WriteLine("Requesting Check Vote");
            var d = await req.Bot.CheckUserVoted(706386087970471968, 642619628375375882);
            Console.WriteLine(JsonConvert.SerializeObject(d));
            d = await req.Bot.CheckUserVoted(706386087970471968, 1);
            Console.WriteLine(JsonConvert.SerializeObject(d));

            Assert.Pass();
        }

        [Test]
        public async Task BotUpdateInfoTest()
        {
            req.Token = Token;
            Console.WriteLine("Requesting Update Info");
            var m = new KoreanBotsUpdateModel(1,1);
            
            var d = await req.Bot.UpdateBotAsync(706386087970471968, m);
            Console.WriteLine(JsonConvert.SerializeObject(d));
            //
            d = await req.Bot.UpdateBotAsync(706386087970471968, m);
            d = await req.Bot.UpdateBotAsync(706386087970471968, m);
            d = await req.Bot.UpdateBotAsync(706386087970471968, m);

            Console.WriteLine(JsonConvert.SerializeObject(d));

            Assert.Pass();
        }

        [Test]
        public async Task UserByIdRequestTest()
        {
            Console.WriteLine("Requesting user using id 642619628375375882");
            var model = await req.User.GetUserAsync(642619628375375882);
            Console.WriteLine(JsonConvert.SerializeObject(model));
            Assert.Pass();
        }
    }
}
