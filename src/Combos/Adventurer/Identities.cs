/*
 * filename: Identities.cs
 * maintainer: VergilGao
 * description:
 *  战斗职业职能技能相关的数据ID
 */

namespace CustomComboPlugin.Combos.Adventurer
{
    internal static class Identities
    {
        public static class Skills
        {
            public const uint
                Swiftcast = 0x1d89, // 即刻咏唱
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
                Swiftcast = 18, // 即刻咏唱
                Placeholder = byte.MaxValue;
        }
    }
}