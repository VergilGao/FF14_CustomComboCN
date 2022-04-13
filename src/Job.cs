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
            Paladin = 0x13, // 骑士
            Warrior = 0x15, // 战士
            WhiteMage = 0x18, // 白魔法师
            Summoner = 0x1b, // 召唤师
            Scholar = 0x1c, // 学者
            Astrologian = 0x21, // 占星术士
            RedMage = 0x23, // 赤魔法师
            Gunbreaker = 0x25, // 绝枪战士
            Dancer = 0x26, // 舞者
            Sage = 0x40, // 贤者
            Placeholder = 0xff;

        public static Dictionary<byte, string> Names = new()
        {
            [Adventurer] = "冒险者",
            [Paladin] = "骑士",
            [Warrior] = "战士",
            [WhiteMage] = "白魔法师",
            [Summoner] = "召唤师",
            [Scholar] = "学者",
            [Astrologian] = "占星术士",
            [RedMage] = "赤魔法师",
            [Gunbreaker] = "绝枪战士",
            [Dancer] = "舞者",
            [Sage] = "贤者",
        };
    }
}