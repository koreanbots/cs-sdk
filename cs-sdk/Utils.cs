using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cs_sdk.Models;

namespace cs_sdk
{
    public static class Utils
    {
        public static KoreanbotsCategory StringToCateGoryEnum(string value)
        {
            switch (value)
            {
                case "관리":
                    return KoreanbotsCategory.Moderation;
                case "뮤직":
                    return KoreanbotsCategory.Music;
                case "전적":
                    return KoreanbotsCategory.History;
                case "게임":
                    return KoreanbotsCategory.Game;
                case "도박":
                    return KoreanbotsCategory.Gambling;
                case "로깅":
                    return KoreanbotsCategory.Logging;
                case "빗금 명령어":
                    return KoreanbotsCategory.SlashCommand;
                case "웹 대시보드":
                    return KoreanbotsCategory.WebDashboard;
                case "밈":
                    return KoreanbotsCategory.Meme;
                case "레벨링":
                    return KoreanbotsCategory.Leveling;
                case "유틸리티":
                    return KoreanbotsCategory.Utility;
                case "대화":
                    return KoreanbotsCategory.Conversation;
                case "NSFW":
                    return KoreanbotsCategory.NSFW;
                case "검색":
                    return KoreanbotsCategory.Search;
                case "학교":
                    return KoreanbotsCategory.School;
                case "코로나19":
                    return KoreanbotsCategory.Covid19;
                case "번역":
                    return KoreanbotsCategory.Translate;
                case "오버워치":
                    return KoreanbotsCategory.Overwatch;
                case "리그 오브 레전드":
                    return KoreanbotsCategory.LeagueofLegends;
                case "배틀그라운드":
                    return KoreanbotsCategory.PUBG;
                case "마인크래프트":
                    return KoreanbotsCategory.Minecraft;
                default:
                    return KoreanbotsCategory.Unknown;
            }
        }
    }
}
