using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_sdk.Models
{
    public enum KoreanBotsBotState
    {
        /// <summary>
        /// 정상
        /// </summary>
        Ok = 0,

        /// <summary>
        /// 일시정지
        /// </summary>
        Reported = 1,

        /// <summary>
        /// 강제 삭제
        /// </summary>
        Blocked = 2,
        
        /// <summary>
        /// 특수 목적 봇
        /// </summary>
        Private = 3,

        /// <summary>
        /// 잠금 처리 (지원 종료)
        /// </summary>
        Archived = 4
    }
}
