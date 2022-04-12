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

    /// <summary>
    /// 英勇之剑状态
    /// </summary>
    [ParentCombo(GoringBladeCombo.Identity)]
    [CustomComboInfo("英勇之剑dot保护", "当目标身上的英勇之剑dot时间超过5s时，用王权剑替换沥血剑", Job.Paladin, Identity, 2)]
    internal sealed class BladeOfValorStatusCombo : CustomCombo
    {
        public const ushort Identity = (Job.Paladin << 8) ^ 0x08;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == Paladin.Identities.Skills.GoringBlade)
            {
                if (comboTime > 0)
                {
                    if (lastComboMove == Paladin.Identities.Skills.RiotBlade)
                    {
                        var bladeOfValor = FindEffectToEnemy(Paladin.Identities.Debuffs.BladeOfValor, SelectedTarget);

                        if (bladeOfValor?.RemainingTime > 5)
                        {
                            return Paladin.Identities.Skills.RoyalAuthority;
                        }
                    }
                }
            }

            return actionID;
        }
    }
}