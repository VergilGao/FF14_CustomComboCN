/*
 * filename: RoyalAuthorityCombo.cs
 * maintainer: VergilGao
 * description:
 *  王权剑连击
 */

using CustomComboPlugin.Attributes;

namespace CustomComboPlugin.Combos.Paladin
{
    /// <summary>
    /// 王权剑连击
    /// </summary>
    [CustomComboInfo("王权剑连击", "用连击替换战女神之怒/王权剑", Job.Paladin, Identity, 0)]
    internal sealed class RoyalAuthorityCombo : CustomCombo
    {
        public const ushort Identity = (Job.Paladin << 8) ^ 0x00;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == Paladin.Identities.Skills.RageOfHalone ||
                actionID == Paladin.Identities.Skills.RoyalAuthority)
            {
                if (comboTime > 0)
                {
                    if (lastComboMove == Paladin.Identities.Skills.RiotBlade &&
                        level >= Paladin.Identities.Levels.RageOfHalone)
                    {
                        // 战女神之怒/王权剑
                        return OriginalHook(Paladin.Identities.Skills.RageOfHalone);
                    }

                    if (lastComboMove == Paladin.Identities.Skills.FastBlade &&
                        level >= Paladin.Identities.Levels.RiotBlade)
                    {
                        return Paladin.Identities.Skills.RiotBlade;
                    }
                }

                return Paladin.Identities.Skills.FastBlade;
            }

            return actionID;
        }
    }
}