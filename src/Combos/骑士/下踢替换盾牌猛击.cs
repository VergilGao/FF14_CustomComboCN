/*
 * filename: ShieldBash.cs
 * maintainer: VergilGao
 * description:
 *  下踢替换盾牌猛击
 */

using CustomComboPlugin.Attributes;

namespace CustomComboPlugin.Combos.骑士
{
    [CustomComboInfo("下踢替换盾牌猛击", "当下踢可用时，下踢替换盾牌猛击", Job.骑士, Identity, 255)]
    internal sealed class 下踢替换盾牌猛击 : CustomCombo
    {
        public const ushort Identity = (Job.骑士 << 8) ^ 0xff;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == Identities.Skills.盾牌猛击)
            {
                if (level >= 冒险者.Identities.Levels.下踢 && IsOffCooldown(冒险者.Identities.Skills.下踢))
                {
                    return 冒险者.Identities.Skills.下踢;
                }
            }

            return actionID;
        }
    }
}