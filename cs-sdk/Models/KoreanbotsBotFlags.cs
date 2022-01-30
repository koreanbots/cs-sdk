using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_sdk.Models
{
    [Flags]
    public enum KoreanBotsBotFlags
    {
        None = 0,
        Official = 1 << 0,
        DBKRVerified  = 1 << 2,
        Partner = 1 << 3,
        DiscordVerified = 1 << 4,
        Premium = 1 << 5
    }
}
