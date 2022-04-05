/*
 * filename: ShieldBash.cs
 * maintainer: VergilGao
 * description:
 *  下踢替换盾牌猛击
 */

using CustomComboPlugin.Attributes;

namespace CustomComboPlugin.Combos.Paladin
{
    /// <summary>
    /// 下踢替换盾牌猛击
    /// </summary>
    [CustomComboInfo("下踢替换盾牌猛击", "当下踢可用时，下踢替换盾牌猛击", Job.Paladin, Identity, 255)]
    internal sealed class ShieldBash : CustomCombo
    {
        public const ushort Identity = (Job.Paladin << 8) ^ 0xff;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == Paladin.Identities.Skills.ShieldBash)
            {
                if (level >= Adventurer.Identities.Levels.LowBlow && IsOffCooldown(Adventurer.Identities.Skills.LowBlow))
                {
                    return Adventurer.Identities.Skills.LowBlow;
                }
            }

            return actionID;
        }
    }
}