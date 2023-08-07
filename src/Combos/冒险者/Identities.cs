/*
 * filename: Identities.cs
 * maintainer: VergilGao
 * description:
 *  战斗职业职能技能相关的数据ID
 */

namespace CustomComboPlugin.Combos.冒险者
{
    internal static class Identities
    {
        public static class Skills
        {
            public const uint
                下踢 = 0x1d74,
                即刻咏唱 = 0x1d89,
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
                下踢 = 12,
                即刻咏唱 = 18,
                Placeholder = byte.MaxValue;
        }
    }
}