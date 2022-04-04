/*
 * filename: CooldownData.cs
 * maintainer: VergilGao
 * description:
 *  技能的冷却数据
 */

using System.Runtime.InteropServices;

namespace CustomComboPlugin
{
    [StructLayout(LayoutKind.Explicit)]
    internal struct CooldownData
    {
        [FieldOffset(0x0)]
        private readonly bool isCooldown;

        [FieldOffset(0x4)]
        private readonly uint actionID;

        [FieldOffset(0x8)]
        private readonly float cooldownElapsed;

        [FieldOffset(0xC)]
        private readonly float cooldownTotal;

        /// <summary>
        /// 技能是否在冷却中
        /// </summary>
        public bool IsCooldown
        {
            get
            {
                var (cur, max) = PluginService.ComboCache.GetMaxCharges(actionID);

                if (cur == max)
                {
                    return isCooldown;
                }

                return cooldownElapsed < CooldownTotal;
            }
        }

        /// <summary>
        /// 技能ID
        /// </summary>
        public uint ActionID => actionID;

        /// <summary>
        /// 技能总的冷却时间
        /// </summary>
        public float CooldownTotal
        {
            get
            {
                if (cooldownTotal == 0)
                {
                    return 0;
                }

                var (cur, max) = PluginService.ComboCache.GetMaxCharges(actionID);
                if (cur == max)
                {
                    return cooldownTotal;
                }

                // Rebase to the current charge count
                var total = cooldownTotal / max * cur;

                if (cooldownElapsed > total)
                {
                    return 0;
                }

                return total;
            }
        }
    }
}