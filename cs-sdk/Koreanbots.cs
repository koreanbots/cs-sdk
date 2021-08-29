using System;

namespace cs_sdk
{
    public class Koreanbots
    {
        public static string Token { get; set; } = null;

        public Koreanbots(string _token = null)
        {
            Token = _token; 
        }


    }
}
