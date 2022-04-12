/*
 * filename: Identities.cs
 * maintainer: VergilGao
 * description:
 *  战士相关的数据ID
 */

namespace CustomComboPlugin.Combos.Warrior
{
    internal static class Identities
    {
        public static class Skills
        {
            public const uint
                HeavySwing = 0x1f, // 重劈
                Maim = 0x25, // 凶残裂
                Berserk = 0x26, // 狂暴
                Overpower = 0x29, // 超压斧
                StormsPath = 0x2a, // 暴风斩
                ThrillOfBattle = 0x28, // 战栗
                InnerBeast = 0x31, // 原初之魂
                MythrilTempest = 0x404e, // 秘银暴风
                SteelCyclone = 0x33, // 钢铁旋风
                StormsEye = 0x2d, // 暴风碎
                Infuriate = 0x34, // 战壕
                FellCleave = 0xddd, // 裂石飞环
                RawIntuition = 0xddf, // 原初的直觉
                Equilibrium = 0xde0, // 泰然自若
                Decimate = 0xdde, // 地毁人亡
                InnerRelease = 0x1cdd, // 原初的解放
                ChaoticCyclone = 0x404f, // 混沌旋风
                NascentFlash = 0x4050, // 原初的勇猛
                InnerChaos = 0x4051, // 狂魂
                Bloodwhetting = 0x6497, // 原初的血气
                PrimalRend = 0x6499, // 蛮荒崩裂
                Placeholder = uint.MaxValue;
        }

        public static class Buffs
        {
            public const ushort
                Berserk = 0x56, // 狂暴
                InnerRelease = 0x499, // 原初的解放
                NascentChaos = 0x769, // 原初的混沌
                PrimalRendReady = 0xa40, // 蛮荒崩裂预备
                SurgingTempest = 0xa75, // 战场风暴
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
                Maim = 4, // 凶残裂
                Berserk = 6, // 狂暴
                StormsPath = 26, // 暴风斩
                ThrillOfBattle = 30, // 战栗
                InnerBeast = 35, // 原初之魂
                MythrilTempest = 40, // 秘银暴风
                SteelCyclone = 45, // 钢铁旋风
                StormsEye = 50, // 暴风碎
                Infuriate = 50, // 战壕
                FellCleave = 54, // 裂石飞环
                RawIntuition = 56, // 原初的直觉
                Equilibrium = 58, // 泰然自若
                Decimate = 60, // 地毁人亡
                InnerRelease = 70, // 原初的解放
                ChaoticCyclone = 72, // 混沌旋风
                NascentFlash = 76, // 原初的勇猛
                InnerChaos = 80, // 狂魂
                Bloodwhetting = 82, // 原初的血气
                PrimalRend = 90, // 蛮荒崩裂
                Placeholder = byte.MaxValue;
        }
    }
}