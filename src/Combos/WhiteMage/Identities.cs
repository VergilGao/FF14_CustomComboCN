/*
 * filename: Identities.cs
 * maintainer: VergilGao
 * description:
 *  白魔法师相关的数据ID
 */

namespace CustomComboPlugin.Combos.WhiteMage
{
    internal static class Identities
    {
        public static class Skills
        {
            public const uint
                Cure = 0x78, // 治疗
                Raise = 0x7d, // 复活
                Cure2 = 0x87, // 救疗
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
                Raise = 12, // 复活
                Cure2 = 30, // 救疗
                Placeholder = byte.MaxValue;
        }
    }
}