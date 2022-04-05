/*
 * filename: Identities.cs
 * maintainer: VergilGao
 * description:
 *  骑士相关的数据ID
 */

namespace CustomComboPlugin.Combos.Paladin
{
    internal static class Identities
    {
        public static class Skills
        {
            public const uint
                FastBlade = 0x09, // 先锋剑
                RiotBlade = 0x0F, // 暴乱剑
                TotalEclipse = 0x1cd5, // 全蚀斩
                ShieldBash = 0x10, // 盾牌猛击
                RageOfHalone = 0x15, // 战女神之怒
                SpiritsWithin = 0x1d, // 深奥之灵
                Prominence = 0x4049, // 日珥斩
                GoringBlade = 0xdd2, // 沥血剑
                CircleOfScorn = 0x17, // 厄运流转
                RoyalAuthority = 0xdd3, // 王权剑
                HolySpirit = 0x1cd8, // 圣灵
                Requiescat = 0x1cd7, // 安魂祈祷
                HolyCircle = 0x404a, // 圣环
                Atonement = 0x404c, // 赎罪剑
                Confiteor = 0x404b, // 悔罪
                Expiacion = 0x6493, // 偿赎剑
                BladeOfFaith = 0x6494, // 信念之剑
                BladeOfTruth = 0x6495, // 真理之剑
                BladeOfValor = 0x6496, // 英勇之剑
            Placeholder = uint.MaxValue;
        }

        public static class Buffs
        {
            public const ushort
                Requiescat = 0x558, // 安魂祈祷
                SwordOath = 0x76e, // 忠义之剑
                Placeholder = ushort.MaxValue;
        }

        public static class Debuffs
        {
            public const ushort
                Placeholder = ushort.MaxValue;
        }

        public static class Levels
        {
            public const byte
                FastBlade = 1, // 先锋剑
                RiotBlade = 4, // 暴乱剑
                TotalEclipse = 6, // 全蚀斩
                ShieldBash = 10, // 盾牌猛击
                RageOfHalone = 26, // 战女神之怒
                SpiritsWithin = 30, // 深奥之灵
                Prominence = 40, // 日珥斩
                GoringBlade = 54, // 沥血剑
                CircleOfScorn = 50, // 厄运流转
                RoyalAuthority = 60, // 王权剑
                HolySpirit = 64, // 圣灵
                Requiescat = 68, // 安魂祈祷
                HolyCircle = 72, // 圣环
                Atonement = 76, // 赎罪剑
                Confiteor = 80, // 悔罪
                Expiacion = 86, // 偿赎剑
                BladeOfFaith = 90, // 信念之剑
                BladeOfTruth = 90, // 真理之剑
                BladeOfValor = 90, // 英勇之剑
                Placeholder = byte.MaxValue;
        }
    }
}