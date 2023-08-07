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
            冒险者 = 0x00, 
            骑士 = 0x13, 
            战士 = 0x15, 
            白魔法师 = 0x18, 
            召唤师 = 0x1b, 
            学者 = 0x1c, 
            占星术士 = 0x21, 
            赤魔法师 = 0x23,
            绝枪战士 = 0x25,
            舞者 = 0x26,
            贤者 = 0x40,
            Placeholder = 0xff;

        public static Dictionary<byte, string> Names = new()
        {
            [冒险者] = "冒险者",
            [骑士] = "骑士",
            [战士] = "战士",
            [白魔法师] = "白魔法师",
            [召唤师] = "召唤师",
            [学者] = "学者",
            [占星术士] = "占星术士",
            [赤魔法师] = "赤魔法师",
            [绝枪战士] = "绝枪战士",
            [舞者] = "舞者",
            [贤者] = "贤者",
        };
    }
}