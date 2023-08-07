/*
 * filename: Identities.cs
 * maintainer: VergilGao
 * description:
 *  骑士相关的数据ID
 */

namespace CustomComboPlugin.Combos.骑士
{
    internal static class Identities
    {
        public static class Skills
        {
            public const uint
                先锋剑 = 0x09, // 先锋剑
                暴乱剑 = 0x0f, // 暴乱剑
                全蚀斩 = 0x1cd5, // 全蚀斩
                盾牌猛击 = 0x10, // 盾牌猛击
                战女神之怒 = 0x15, // 战女神之怒
                深奥之灵 = 0x1d, // 深奥之灵
                日珥斩 = 0x4049, // 日珥斩
                沥血剑 = 0xdd2, // 沥血剑
                厄运流转 = 0x17, // 厄运流转
                王权剑 = 0xdd3, // 王权剑
                圣灵 = 0x1cd8, // 圣灵
                安魂祈祷 = 0x1cd7, // 安魂祈祷
                圣环 = 0x404a, // 圣环
                赎罪剑 = 0x404c, // 赎罪剑
                悔罪 = 0x404b, // 悔罪
                偿赎剑 = 0x6493, // 偿赎剑
                信念之剑 = 0x6494, // 信念之剑
                真理之剑 = 0x6495, // 真理之剑
                英勇之剑 = 0x6496, // 英勇之剑
            Placeholder = uint.MaxValue;
        }

        public static class Buffs
        {
            public const ushort
                战逃反应 = 0x4c,
                安魂祈祷 = 0x558,
                忠义之剑 = 0x76e,
                神圣魔法效果提高 = 0xa71,
                悔罪预备 = 0xbcb,
                Placeholder = ushort.MaxValue;
        }

        public static class Debuffs
        {
            public const ushort
                BladeOfValor = 0xaa1, // 英勇之剑
                Placeholder = ushort.MaxValue;
        }

        public static class Levels
        {
            public const byte
                先锋剑 = 1, // 先锋剑
                暴乱剑 = 4, // 暴乱剑
                全蚀斩 = 6, // 全蚀斩
                盾牌猛击 = 10, // 盾牌猛击
                战女神之怒 = 26, // 战女神之怒
                深奥之灵 = 30, // 深奥之灵
                日珥斩 = 40, // 日珥斩
                沥血剑 = 54, // 沥血剑
                厄运流转 = 50, // 厄运流转
                王权剑 = 60, // 王权剑
                圣灵 = 64, // 圣灵
                安魂祈祷 = 68, // 安魂祈祷
                圣环 = 72, // 圣环
                赎罪剑 = 76, // 赎罪剑
                悔罪 = 80, // 悔罪
                偿赎剑 = 86, // 偿赎剑
                信念之剑 = 90, // 信念之剑
                真理之剑 = 90, // 真理之剑
                英勇之剑 = 90, // 英勇之剑
                Placeholder = byte.MaxValue;
        }
    }
}