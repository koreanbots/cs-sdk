using cs_sdk;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace cs_sdk_tests
{
    public class RequestTest
    {
        private KoreanbotsRequester req;
        [SetUp]
        public void Setup()
        {
            req = new KoreanbotsRequester();
        }

        [Test]
        public async Task BotByIdRequestTest()
        {
            Console.WriteLine("Requesting bot using id 387548561816027138");
            var model = await req.RequestBotByIdAsync(387548561816027138);
            Console.WriteLine(JsonConvert.SerializeObject(model));
            Assert.Pass();
        }

        [Test]
        public async Task BotSearchRequestTest()
        {
            Console.WriteLine("Searching bots using query wonder");
            var model = await req.SearchBotByIdAsync("wonder");
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
                await req.SearchBotByIdAsync("");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                a = true;
            }
            try
            {
                await req.SearchBotByIdAsync(null);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                b = true;
            }
            try
            {
                await req.SearchBotByIdAsync("  ");
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
                await req.SearchBotByIdAsync("1");
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

            var d = await req.SearchBotByIdAsync("대충없는거");
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
            var d = await req.GetBotsByNewAsync();
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
            var d = await req.GetBotsByVotedAsync();
            if (d.Count == 0)
            {
                Assert.Fail();
                return;
            }
            Console.WriteLine(JsonConvert.SerializeObject(d));
            Assert.Pass();
        }

        [Test]
        public async Task BotCheckVoteTest()
        {
            Koreanbots.Token =
                "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjcwNjM4NjA4Nzk3MDQ3MTk2OCIsImlhdCI6MTYzMDExNjUxM30.b6naW7DSoLrXM5TE7Vy3IzLxoh2UqbxcH6R3ej7UUVYDtbo-qHOedWFNOzXRfyrWkFJ9TNJOJVwkZpgXP5BsSb-vXogbsAoQ_wNUgnrLKT_cJac2YBfLcyqiXSwQ7Q-h7EfsJpo_bnTQvoqEIROXjUHsCgpUKIE0Wxbn22CWo5Q";
            Console.WriteLine("Requesting Check Vote");
            var d = await req.CheckVoteAsync(706386087970471968, 642619628375375882);
            Console.WriteLine(JsonConvert.SerializeObject(d));
            d = await req.CheckVoteAsync(706386087970471968, 1);
            Console.WriteLine(JsonConvert.SerializeObject(d));

            Assert.Pass();
        }
    }
}
