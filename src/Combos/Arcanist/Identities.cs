/*
 * filename: Identities.cs
 * maintainer: VergilGao
 * description:
 *  秘术师相关的数据ID
 */

namespace CustomComboPlugin.Combos.Arcanist
{
    internal static class Identities
    {
        public static class Skills
        {
            public const uint
                Resurrection = 0xad, // 复生
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
                Resurrection = 12, // 复生
                Placeholder = byte.MaxValue;
        }
    }
}