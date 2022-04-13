/*
 * filename: SingleCombo.cs
 * maintainer: VergilGao
 * description:
 *  单体连击
 */

using CustomComboPlugin.Attributes;

using Dalamud.Game.ClientState.JobGauge.Types;

namespace CustomComboPlugin.Combos.Dancer
{
    /// <summary>
    /// 单体连击
    /// </summary>
    [CustomComboInfo("瀑泻连击", "连击替换瀑泻", Job.Dancer, Identity, 0)]
    internal sealed class SingleCombo : CustomCombo
    {
        public const ushort Identity = (Job.Dancer << 8) ^ 0x00;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == Dancer.Identities.Skills.Cascade &&
                !(HasSelfEffect(Dancer.Identities.Buffs.StandardStep) || HasSelfEffect(Dancer.Identities.Buffs.TechnicalStep)))
            {
                if (level >= Dancer.Identities.Levels.Fountainfall && HasSelfEffect(Dancer.Identities.Buffs.FlourishingFlow))
                {
                    return Dancer.Identities.Skills.Fountainfall;
                }

                if (level >= Dancer.Identities.Levels.ReverseCascade && HasSelfEffect(Dancer.Identities.Buffs.FlourishingSymmetry))
                {
                    return Dancer.Identities.Skills.ReverseCascade;
                }

                if (lastComboMove == Dancer.Identities.Skills.Cascade)
                {
                    return Dancer.Identities.Skills.Fountain;
                }
            }

            return actionID;
        }
    }

    /// <summary>
    /// 舞步连击
    /// </summary>
    [SecretCombo]
    [ParentCombo(SingleCombo.Identity)]
    [CustomComboInfo("瀑泻-舞步连击", "发动舞步时，将下一个舞步技能替换到瀑泻上", Job.Dancer, Identity, 1)]
    internal sealed class SingleDancingStep : CustomCombo
    {
        public const ushort Identity = (Job.Dancer << 8) ^ 0x03;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == Dancer.Identities.Skills.Cascade)
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