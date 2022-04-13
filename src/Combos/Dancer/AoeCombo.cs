/*
 * filename: AoeCombo.cs
 * maintainer: VergilGao
 * description:
 *  群体连击
 */

using CustomComboPlugin.Attributes;

using Dalamud.Game.ClientState.JobGauge.Types;

namespace CustomComboPlugin.Combos.Dancer
{
    /// <summary>
    /// 群体连击
    /// </summary>
    [CustomComboInfo("风车连击", "连击替换风车", Job.Dancer, Identity, 1)]
    internal sealed class AoeCombo : CustomCombo
    {
        public const ushort Identity = (Job.Dancer << 8) ^ 0x01;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == Dancer.Identities.Skills.Windmill &&
                !(HasSelfEffect(Dancer.Identities.Buffs.StandardStep) || HasSelfEffect(Dancer.Identities.Buffs.TechnicalStep)))
            {
                if (level >= Dancer.Identities.Levels.Bloodshower && HasSelfEffect(Dancer.Identities.Buffs.FlourishingFlow))
                {
                    return Dancer.Identities.Skills.Bloodshower;
                }

                if (level >= Dancer.Identities.Levels.RisingWindmill && HasSelfEffect(Dancer.Identities.Buffs.FlourishingSymmetry))
                {
                    return Dancer.Identities.Skills.RisingWindmill;
                }

                if (lastComboMove == Dancer.Identities.Skills.Windmill)
                {
                    return Dancer.Identities.Skills.Bladeshower;
                }
            }

            return actionID;
        }
    }

    /// <summary>
    /// 舞步连击
    /// </summary>
    [SecretCombo]
    [ParentCombo(AoeCombo.Identity)]
    [CustomComboInfo("风车-舞步连击", "发动舞步时，将下一个舞步技能替换到风车上", Job.Dancer, Identity, 2)]
    internal sealed class AoeDancingStep : CustomCombo
    {
        public const ushort Identity = (Job.Dancer << 8) ^ 0x04;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == Dancer.Identities.Skills.Windmill)
            {
                var gauge = GetJobGauge<DNCGauge>();

                if (level >= Dancer.Identities.Levels.StandardStep && gauge.IsDancing && HasSelfEffect(Dancer.Identities.Buffs.StandardStep))
                {
                    if (gauge.CompletedSteps < 2)
                    {
                        return gauge.NextStep;
                    }

                    return OriginalHook(Dancer.Identities.Skills.StandardStep);
                }

                if (level >= Dancer.Identities.Levels.TechnicalStep && gauge.IsDancing && HasSelfEffect(Dancer.Identities.Buffs.TechnicalStep))
                {
                    if (gauge.CompletedSteps < 4)
                    {
                        return gauge.NextStep;
                    }

                    return OriginalHook(Dancer.Identities.Skills.TechnicalStep);
                }
            }

            return actionID;
        }
    }
}