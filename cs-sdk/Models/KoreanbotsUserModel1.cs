using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace cs_sdk.Models
{
    public class KoreanBotsUserModel1
    {
        /// <summary>
        /// 유저의 ID를 반환합니다.
        /// </summary>
        [JsonProperty("id")]
        public ulong Id { get; set; }

        /// <summary>
        /// 유저의 디스코드 사용자 이름을 반환합니다.
        /// </summary>
        [JsonProperty("username")]
        public string Username { get; set; }

        /// <summary>
        /// 유저의 디스코드 태그를 반환합니다.
        /// </summary>
        [JsonProperty("tag")]
        public string Discriminator { get; set; }

        /// <summary>
        /// 유저의 깃허브 사용자 이름을 반환합니다. 만약 깃허브 사용자 이름이 설정되지 않은 경우, 빈 문자열을 반환합니다.
        /// </summary>
        /// <returns>깃허브 사용자 이름이 설정되지 않은 경우, 빈 문자열을 반환합니다.</returns>
        [JsonProperty("github", NullValueHandling = NullValueHandling.Ignore)]
        public string Github { get; set; } = "";

        /// <summary>
        /// 유저의 플래그를 반환합니다.
        /// </summary>
        [JsonProperty("flags")]
        public KoreanBotsUserFlags Flags { get; set; } = KoreanBotsUserFlags.None;

        /// <summary>
        /// 유저가 소유한 봇들을 반환합니다. (단, 소유자는 아이디만 표시됩니다.)
        /// </summary>
        [JsonProperty("bots")]
        public List<ulong> Bots { get; set; } = new();
    }
}
