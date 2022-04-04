/*
 * filename: Identities.cs
 * maintainer: VergilGao
 * description:
 *  占星术士相关的数据ID
 */

namespace CustomComboPlugin.Combos.Astrologian
{
    internal static class Identities
    {
        public static class Skills
        {
            public const uint
                Benfic = 0xe0a, // 吉星
                Ascend = 0xe13, // 生辰
                Benefic2 = 0xe1a, // 福星
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
                Ascend = 12, // 生辰
                Benefic2 = 26, // 福星
                Placeholder = byte.MaxValue;
        }
    }
}