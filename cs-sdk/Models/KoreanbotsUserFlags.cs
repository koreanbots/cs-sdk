using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_sdk.Models
{
    [Flags]
    public enum KoreanBotsUserFlags
    {
        None = 0,
        Administrator = 1 << 0,
        BugHunter = 1 << 1,
        Reviewer = 1 << 2,
        Premium = 1 << 3
    }
}
