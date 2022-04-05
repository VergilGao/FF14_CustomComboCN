/*
 * filename: GoringBladeCombo.cs
 * maintainer: VergilGao
 * description:
 *  沥血剑连击
 */

using CustomComboPlugin.Attributes;

namespace CustomComboPlugin.Combos.Paladin
{
    /// <summary>
    /// 王权剑连击
    /// </summary>
    [CustomComboInfo("沥血剑连击", "用连击替换沥血剑", Job.Paladin, Identity, 1)]
    internal sealed class GoringBladeCombo : CustomCombo
    {
        public const ushort Identity = (Job.Paladin << 8) ^ 0x01;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == Paladin.Identities.Skills.GoringBlade)
            {
                if (comboTime > 0)
                {
                    if (lastComboMove == Paladin.Identities.Skills.RiotBlade &&
                        level >= Paladin.Identities.Levels.GoringBlade)
                    {
                        return Paladin.Identities.Skills.GoringBlade;
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