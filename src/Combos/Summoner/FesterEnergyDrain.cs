/*
 * filename: FesterEnergyDrain.cs
 * maintainer: VergilGao
 * description:
 *  能量吸收替换溃烂爆发
 */

using CustomComboPlugin.Attributes;

using Dalamud.Game.ClientState.JobGauge.Types;

namespace CustomComboPlugin.Combos.Summoner
{
    [CustomComboInfo("能量吸收替换溃烂爆发", "当以太超流耗尽时，能量吸收替换溃烂爆发", Job.Summoner, Identity, 0)]
    internal sealed class FesterEnergyDrain : CustomCombo
    {
        public const ushort Identity = (Job.Summoner << 8) ^ 0x00;

        protected override uint Invoke(uint actionId, uint lastComboMove, float comboTime, byte level)
        {
            if (actionId == Summoner.Identities.Skills.Fester)
            {
                var guauge = GetJobGauge<SMNGauge>();

                if (level >= Summoner.Identities.Levels.EnergyDrain && !guauge.HasAetherflowStacks)
                {
                    return Summoner.Identities.Skills.EnergyDrain;
                }
            }

            return actionId;
        }
    }
}