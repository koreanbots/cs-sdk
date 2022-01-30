using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace cs_sdk.Models
{
    public enum KoreanBotsCategory
    {
        /// <summary>
        /// 알수없음
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// 관리
        /// </summary>
         Moderation = 1,
         
         /// <summary>
         /// 뮤직
         /// </summary>
         Music = 2,

         /// <summary>
         /// 전적
         /// </summary>
         History = 3,

         /// <summary>
         /// 게임
         /// </summary>
         Game = 4,

         /// <summary>
         /// 도박
         /// </summary>
         Gambling = 5,

         /// <summary>
         /// 로깅
         /// </summary>
         Logging = 6,

        /// <summary>
        /// 빗금 명령어
        /// </summary>
        SlashCommand = 7,

        /// <summary>
        /// 웹 대시보드
        /// </summary>
        WebDashboard = 8,

        /// <summary>
        /// 밈
        /// </summary>
        Meme = 9,

        /// <summary>
        /// 레벨링
        /// </summary>
        Leveling = 10,

        /// <summary>
        /// 유틸리티
        /// </summary>
        Utility = 11,

        /// <summary>
        /// 대화
        /// </summary>
        Conversation = 12,

        /// <summary>
        /// NSFW
        /// </summary>
        NSFW = 13,

        /// <summary>
        /// 검색
        /// </summary>
        Search = 14,

        /// <summary>
        /// 학교
        /// </summary>
        School = 15,

        /// <summary>
        /// 코로나19
        /// </summary>
        Covid19 = 16,

        /// <summary>
        /// 번역
        /// </summary>
        Translate = 17,

        /// <summary>
        /// 오버워치
        /// </summary>
        Overwatch = 18,

        /// <summary>
        /// 리그오브레전드
        /// </summary>
        LeagueofLegends = 19,

        /// <summary>
        /// 배틀그라운드
        /// </summary>
        PUBG = 20,

        /// <summary>
        /// 마인크래프트
        /// </summary>
        Minecraft = 21
    }
}
