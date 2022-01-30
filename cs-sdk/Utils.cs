using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using cs_sdk.Exceptions;
using cs_sdk.Models;
using RestSharp;

namespace cs_sdk
{
    public static class Utils
    {
        public static KoreanBotsCategory StringToCategoryEnum(string value)
        {
            switch (value)
            {
                case "관리":
                    return KoreanBotsCategory.Moderation;
                case "뮤직":
                    return KoreanBotsCategory.Music;
                case "전적":
                    return KoreanBotsCategory.History;
                case "게임":
                    return KoreanBotsCategory.Game;
                case "도박":
                    return KoreanBotsCategory.Gambling;
                case "로깅":
                    return KoreanBotsCategory.Logging;
                case "빗금 명령어":
                    return KoreanBotsCategory.SlashCommand;
                case "웹 대시보드":
                    return KoreanBotsCategory.WebDashboard;
                case "밈":
                    return KoreanBotsCategory.Meme;
                case "레벨링":
                    return KoreanBotsCategory.Leveling;
                case "유틸리티":
                    return KoreanBotsCategory.Utility;
                case "대화":
                    return KoreanBotsCategory.Conversation;
                case "NSFW":
                    return KoreanBotsCategory.NSFW;
                case "검색":
                    return KoreanBotsCategory.Search;
                case "학교":
                    return KoreanBotsCategory.School;
                case "코로나19":
                    return KoreanBotsCategory.Covid19;
                case "번역":
                    return KoreanBotsCategory.Translate;
                case "오버워치":
                    return KoreanBotsCategory.Overwatch;
                case "리그 오브 레전드":
                    return KoreanBotsCategory.LeagueofLegends;
                case "배틀그라운드":
                    return KoreanBotsCategory.PUBG;
                case "마인크래프트":
                    return KoreanBotsCategory.Minecraft;
                default:
                    return KoreanBotsCategory.Unknown;
            }
        }

        public static void CheckHttpException(IRestResponse response, bool ignoreNotFound = false, bool ignoreTooMany = false)
        {
            if (ignoreTooMany && response.StatusCode == HttpStatusCode.TooManyRequests) return;
            if (ignoreNotFound && response.StatusCode == HttpStatusCode.NotFound) return;
            if (!response.IsSuccessful || response.StatusCode != HttpStatusCode.OK)
            {
                throw new KoreanBotsHttpException(
                    $"The server responded with error {(int)response.StatusCode} {response.StatusCode}");
            }
        }
    }
}
