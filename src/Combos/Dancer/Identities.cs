/*
 * filename: Identities.cs
 * maintainer: VergilGao
 * description:
 *  舞者相关的数据ID
 */

namespace CustomComboPlugin.Combos.Dancer
{
    internal static class Identities
    {
        public static class Skills
        {
            public const uint
                Cascade = 0x3e75, // 瀑泻
                Fountain = 0x3e76, // 喷泉
                ReverseCascade = 0x3e77, // 逆瀑泻
                Fountainfall = 0x3e78, // 坠喷泉
                Windmill = 0x3e79, // 风车
                Bladeshower = 0x3e7a, // 落刃雨
                RisingWindmill = 0x3e7b, // 升风车
                Bloodshower = 0x3e7c, // 落血雨
                StandardStep = 0x3e7d, // 标准舞步
                TechnicalStep = 0x3e7e, // 技巧舞步
                Tillana = 0x64be, // 提拉纳
                FanDance1 = 0x3e87, // 扇舞·序
                FanDance2 = 0x3e88, // 扇舞·破
                FanDance3 = 0x3e89, // 扇舞·急
                FanDance4 = 0x64bf, // 扇舞·终
                SaberDance = 0x3e85, // 剑舞
                EnAvant = 0x3e8a, // 前冲步
                Devilment = 0x3e8b, // 进攻之探戈
                Flourish = 0x3e8d, // 百花争艳
                Improvisation = 0x3e8e, // 即兴表演
                StarfallDance = 0x64c0, // 流星舞
                Placeholder = uint.MaxValue;
        }

        public static class Buffs
        {
            public const ushort
                FlourishingSymmetry = 0xa85, // 对称投掷
                FlourishingFlow = 0xa86, // 非对称投掷
                FlourishingFinish = 2698, // 提拉纳预备
                FlourishingStarfall = 0xa8a, // 流星舞预备
                StandardStep = 0x71a, // 标准舞步
                TechnicalStep = 0x71b, // 技巧舞步
                ThreefoldFanDance = 0x71c, // 扇舞·急预备
                FourfoldFanDance = 0xa8b, // 扇舞·终预备
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
                Cascade = 1, // 瀑泻
                Fountain = 2, // 喷泉
                Windmill = 15, // 风车
                StandardStep = 15, // 标准舞步
                ReverseCascade = 20, // 逆瀑泻
                Bladeshower = 25, // 落刃雨
                RisingWindmill = 35, // 升风车
                Fountainfall = 40, // 坠喷泉
                Bloodshower = 45, // 落血雨
                FanDance3 = 66, // 扇舞·急
                TechnicalStep = 70, // 技巧舞步
                Flourish = 72, // 百花争艳
                Tillana = 82, // 提拉纳
                FanDance4 = 86, // 扇舞·终
                StarfallDance = 90, // 流星舞
                Placeholder = byte.MaxValue;
        }
    }
}