/*
 * filename: Identities.cs
 * maintainer: VergilGao
 * description:
 *  贤者相关的数据ID
 */

namespace CustomComboPlugin.Combos.Sage
{
    internal static class Identities
    {
        public static class Skills
        {
            public const uint
                Egeiro = 0x5edf, // 复苏
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
                Egeiro = 12, // 复苏
                Placeholder = byte.MaxValue;
        }
    }
}