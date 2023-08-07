/*
 * filename: PainflareEnergySyphon.cs
 * maintainer: VergilGao
 * description:
 *  能量抽取替换痛苦核爆
 */

using CustomComboPlugin.Attributes;

using Dalamud.Game.ClientState.JobGauge.Types;

namespace CustomComboPlugin.Combos.Summoner
{
    [CustomComboInfo("能量抽取替换痛苦核爆", "当以太超流耗尽时，能量抽取替换痛苦核爆", Job.召唤师, Identity, 1)]
    internal sealed class PainflareEnergySyphon : CustomCombo
    {
        public const ushort Identity = (Job.召唤师 << 8) ^ 0x01;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == Summoner.Identities.Skills.Painflare)
            {
                var guauge = GetJobGauge<SMNGauge>();

                if (level >= Summoner.Identities.Levels.EnergySyphon && !guauge.HasAetherflowStacks)
                {
                    return Summoner.Identities.Skills.EnergySyphon;
                }
            }

            return actionID;
        }
    }
}