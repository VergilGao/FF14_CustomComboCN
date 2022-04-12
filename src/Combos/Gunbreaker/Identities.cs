/*
 * filename: Identities.cs
 * maintainer: VergilGao
 * description:
 *  绝枪战士相关的数据ID
 */

namespace CustomComboPlugin.Combos.Gunbreaker
{
    internal static class Identities
    {
        public static class Skills
        {
            public const uint
                KeenEdge = 0x3f09, // 利刃斩
                NoMercy = 0x3f0a, // 无情
                BrutalShell = 0x3f0b, // 残暴弹
                DemonSlice = 0x3f0d, // 恶魔切
                SolidBarrel = 0x3f11, // 迅连斩
                BurstStrike = 0x3f22, // 爆发击
                DemonSlaughter = 0x3f15, // 恶魔杀
                SonicBreak = 0x3f19, // 音速破
                GnashingFang = 0x3f12, // 烈牙
                BowShock = 0x3f1f, // 弓形冲波
                Continuation = 0x3f1b, // 续剑
                JugularRip = 0x3f1c, // 撕喉
                AbdomenTear = 0x3f1d, // 裂膛
                EyeGouge = 0x3f1e, // 穿目
                FatedCircle = 0x3f23, // 命运之环
                Bloodfest = 0x3f24, // 血壤
                EnhancedContinuation = 0x649f, // 超高速
                DoubleDown = 0x64a0, // 倍攻
                Placeholder = uint.MaxValue;
        }

        public static class Buffs
        {
            public const ushort
                NoMercy = 0x727, // 无情
                ReadyToRip = 0x732, // 撕喉预备
                ReadyToTear = 0x733, // 裂膛预备
                ReadyToGouge = 0x734, // 穿目预备
                ReadyToBlast = 0xa7e, // 超高速预备
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
                NoMercy = 2, // 无情
                BrutalShell = 4, // 残暴弹
                SolidBarrel = 26, // 迅连斩
                BurstStrike = 30, // 爆发击
                DemonSlaughter = 40, // 恶魔杀
                SonicBreak = 54, // 音速破
                GnashingFang = 60, // 烈牙
                BowShock = 62, // 弓形冲波
                Continuation = 70, // 续剑
                FatedCircle = 72, // 命运之环
                Bloodfest = 76, // 血壤
                EnhancedContinuation = 86, // 超高速
                CartridgeCharge2 = 88, // 晶壤装填效果提高
                DoubleDown = 90, // 倍攻
                Placeholder = byte.MaxValue;
        }
    }
}