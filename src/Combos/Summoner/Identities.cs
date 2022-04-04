/*
 * filename: Identities.cs
 * maintainer: VergilGao
 * description:
 *  召唤师相关的数据ID
 */

namespace CustomComboPlugin.Combos.Summoner
{
    internal static class Identities
    {
        public static class Skills
        {
            public const uint
                SummonCarbuncle = 0x64c6, // 宝石兽召唤
                Gemshine = 0x64c8, // 以太蓄能
                Fester = 0xb5, // 溃烂爆发
                EnergyDrain = 0x407c, // 能量吸收
                Resurrection = 0xad, // 复生
                Painflare = 0xdfa, // 痛苦核爆
                EnergySyphon = 0x407e, // 能量抽取
                Placeholder = uint.MaxValue;
        }

        public static class Buffs
        {
            public const ushort
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
                SummonCarbuncle = 2, // 宝石兽召唤
                Gemshine = 6, // 以太蓄能
                Fester = 10, // 溃烂爆发
                EnergyDrain = 10, // 能量吸收
                Resurrection = 12, // 复生
                Painflare = 40, // 痛苦核爆
                EnergySyphon = 52, // 能量抽取
                Placeholder = byte.MaxValue;
        }
    }
}