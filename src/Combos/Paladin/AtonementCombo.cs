/*
 * filename: AtonementCombo.cs
 * maintainer: VergilGao
 * description:
 *  王权剑-赎罪连击
 */

using CustomComboPlugin.Attributes;

namespace CustomComboPlugin.Combos.Paladin
{
    /// <summary>
    /// 王权剑-赎罪连击
    /// </summary>
    [CustomComboInfo("赎罪连击", "忠义之剑生效中，赎罪替换王权剑", Job.Paladin, Identity, 2)]
    internal sealed class AtonementCombo : CustomCombo
    {
        public const ushort Identity = (Job.Paladin << 8) ^ 0x02;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == Paladin.Identities.Skills.RoyalAuthority)
            {
                if (level >= Paladin.Identities.Levels.Atonement &&
                    HasSelfEffect(Paladin.Identities.Buffs.SwordOath) &&
                    lastComboMove != Paladin.Identities.Skills.FastBlade &&
                    lastComboMove != Paladin.Identities.Skills.RiotBlade)
                {
                    return Paladin.Identities.Skills.Atonement;
                }
            }

            return actionID;
        }
    }
}