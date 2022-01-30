using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace cs_sdk.Models
{
    public class KoreanBotsUserVote
    {
        /// <summary>
        /// 12시간이내 투표 여부를 반환합니다.
        /// </summary>
        [JsonProperty("voted")]
        public bool Voted { get; set; } = false;
        /// <summary>
        /// 가장 최근 투표 시간을 반환합니다.
        /// </summary>
        public DateTime? LastVotedTime { get; set; } = null;
    }
}
