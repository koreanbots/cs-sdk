using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace cs_sdk.Models
{
    public class KoreanbotsBotModel
    {
        /// <summary>
        /// 봇의 ID를 반환합니다.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// 봇의 디스코드 사용자 이름을 반환합니다.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 봇의 디스코드 태그를 반환합니다.
        /// </summary>
        [JsonProperty("tag")]
        public string Discriminator { get; set; }

        ///<returns>아바타가 설정되지 않은 경우, null을 반환합니다.</returns>
        /// <summary>봇의 아바타 해시를 반환합니다. 만약 설정되지 않은 경우, null을 반환합니다.</summary>
        public string Avatar { get; set; } = null;
        
        /// <summary>
        /// 봇의 소유자 목록을 반환합니다. (소유한 봇은 아이디만 표시됩니다.)
        /// </summary>
        public List<KoreanbotsUserModel1> Owners = new ();

        /// <summary>
        /// 봇의 플래그를 반환합니다.
        /// </summary>
        /// <see cref="KoreanbotsBotFlags"/>
        [JsonProperty("flags")]
        public int Flags = 0;

        /// <summary>
        /// 봇의 라이브러리를 반환합니다.
        /// </summary>
        [JsonProperty("lib")]
        public string Library { get; set; }

        /// <summary>
        /// 봇의 접두사를 반환합니다.
        /// </summary>
        [JsonProperty("prefix")]
        public string Prefix { get; set; }

        /// <summary>
        /// 봇의 하트 수를 반환합니다.
        /// </summary>
        [JsonProperty("votes")]
        public int Votes { get; set; } = 0;

        /// <summary>
        /// 봇의 서버 수를 반환합니다.
        /// </summary>
        [JsonProperty("servers")]
        public int Servers { get; set; } = 0;

        /// <summary>
        /// 봇의 짧은 설명을 반환합니다.
        /// </summary>
        [JsonProperty("intro")]
        public string Intro { get; set; }

        /// <summary>
        /// 봇의 긴 설명을 반환합니다.
        /// </summary>
        [JsonProperty("desc")]
        public string Description { get; set; }
        
        ///<returns>웹주소가 설정되지 않은 경우, null을 반환합니다.</returns>
        /// <summary>봇의 웹사이트 주소를 반환합니다. 만약 설정되지 않은 경우, null을 반환합니다.</summary>
        public string Web { get; set; } = null;
        
        ///<returns>깃주소가 설정되지 않은 경우, null을 반환합니다.</returns>
        /// <summary>봇의 깃주소를 반환합니다. 만약 설정되지 않은 경우, null을 반환합니다.</summary>
        public string Git { get; set; } = null;
        
        ///<returns>커스텀 초대링크가 설정되지 않은 경우, null을 반환합니다.</returns>
        /// <summary>봇의 커스텀 초대링크를 반환합니다. 만약 설정되지 않은 경우, null을 반환합니다.</summary>
        public string CustomUrl { get; set; } = null;
        
        ///<returns>초대링크가 설정되지 않은 경우, null을 반환합니다.</returns>
        /// <summary>봇의 디스코드 초대링크를 반환합니다. 만약 설정되지 않은 경우, null을 반환합니다.</summary>
        public string Discord { get; set; } = null;
        
        /// <summary>
        /// 봇의 카테고리를 반환합니다.
        /// </summary>
        public List<KoreanbotsCategory> Categories { get; set; } = new();
        
        /// <summary>봇의 Vanity주소를 반환합니다. 만x약 설정되지 않은 경우, null을 반환합니다.</summary>
        /// <returns>Vanity주소가 설정되지 않은 경우, null을 반환합니다.</returns>
        /// <seealso cref="https://koreanbots.dev/verification"/>
        public string Vanity { get; set; } = null;
        
        /// <summary>봇의 배경이미지 주소를 반환합니다. 만약 설정되지 않은 경우, null을 반환합니다.</summary>
        /// <returns>배경 이미지 주소가 설정되지 않은 경우, null을 반환합니다.</returns>
        /// <seealso cref="https://koreanbots.dev/verification"/>
        public string Bg { get; set; } = null;
        
        /// <summary>봇의 배너 이미지 주소를 반환합니다. 만약 설정되지 않은 경우, null을 반환합니다.</summary>
        /// <returns>배너 이미지 주소가 설정되지 않은 경우, null을 반환합니다.</returns>
        /// <seealso cref="https://koreanbots.dev/verification"/>
        public string Banner { get; set; } = null;
        
        /// <summary>봇의 유저 상태를 반환합니다. 만약 설정되지 않은 경우, Unknown을 반환합니다.</summary>
        /// <returns>상태가 설정되지 않은 경우, Unknown을 반환합니다.</returns>
        public KoreanbotsBotStatus Status { get; set; } = KoreanbotsBotStatus.Unknown;

        /// <summary>
        /// DBKR에서의 봇의 상태를 반환합니다.
        /// </summary>
        public KoreanbotsBotState State { get; set; }
    }
}
