/*
 * filename: Job.cs
 * maintainer: VergilGao
 * description:
 *  职业相关的数据ID
 */

using System.Collections.Generic;

namespace CustomComboPlugin
{
    internal static class Job
    {
        public const byte
            Adventurer = 0x00, // 冒险者
            WhiteMage = 0x18, // 白魔法师
            Summoner = 0x1b, // 召唤师
            Astrologian = 0x21, // 占星术士
            Placeholder = 0xff;

        public static Dictionary<byte, string> Names = new()
        {
            [Adventurer] = "冒险者",
            [WhiteMage] = "白魔法师",
            [Summoner] = "召唤师",
            [Astrologian] = "占星术士",
        };
    }
}