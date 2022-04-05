/*
 * filename: Identities.cs
 * maintainer: VergilGao
 * description:
 *  学者相关的数据ID
 */

namespace CustomComboPlugin.Combos.Scholar
{
    internal static class Identities
    {
        public static class Skills
        {
            public const uint
                Physick = 0xbe, // 医术
                SummonEos = 0x433f, // 朝日召唤
                SummonSelene = 0x4340, // 夕月召唤
                Adloquium = 0xb9, // 鼓舞激励之策
                Dissipation = 0xe03, // 转化
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
                Physick = 4, // 医术
                SummonEos = 4, // 朝日召唤
                SummonSelene = 4, // 夕月召唤
                Adloquium = 30, // 鼓舞激励之策
                Dissipation = 60, // 转化
                Placeholder = byte.MaxValue;
        }
    }
}