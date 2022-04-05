/*
 * filename: Identities.cs
 * maintainer: VergilGao
 * description:
 *  赤魔法师相关的数据ID
 */

namespace CustomComboPlugin.Combos.RedMage
{
    internal static class Identities
    {
        public static class Skills
        {
            public const uint
                Verraise = 0x1d63, // 赤复活
                Placeholder = uint.MaxValue;
        }

        public static class Buffs
        {
            public const ushort
                Dualcast = 0x4e1, // 连续咏唱
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
                Verraise = 64, // 赤复活
                Placeholder = byte.MaxValue;
        }
    }
}