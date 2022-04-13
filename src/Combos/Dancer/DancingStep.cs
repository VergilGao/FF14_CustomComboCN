/*
 * filename: DancingCombo.cs
 * maintainer: VergilGao
 * description:
 *  舞步连击
 */

using CustomComboPlugin.Attributes;

using Dalamud.Game.ClientState.JobGauge.Types;

namespace CustomComboPlugin.Combos.Dancer
{
    /// <summary>
    /// 舞步连击
    /// </summary>
    [SecretCombo]
    [CustomComboInfo("舞步连击", "发动舞步时，将下一个舞步技能替换到对应舞步上", Job.Dancer, Identity, 255)]
    internal sealed class DancingStep : CustomCombo
    {
        public const ushort Identity = (Job.Dancer << 8) ^ 0xff;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == Dancer.Identities.Skills.StandardStep)
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
            }
            else if (actionID == Dancer.Identities.Skills.TechnicalStep)
            {
                var gauge = GetJobGauge<DNCGauge>();

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