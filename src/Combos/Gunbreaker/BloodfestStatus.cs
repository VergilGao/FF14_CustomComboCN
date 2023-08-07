/*
 * filename: BloodfestStatus.cs
 * maintainer: VergilGao
 * description:
 *  血壤状态
 */

using CustomComboPlugin.Attributes;

using Dalamud.Game.ClientState.JobGauge.Types;

namespace CustomComboPlugin.Combos.Gunbreaker
{
    /// <summary>
    /// 血壤状态
    /// </summary>
    [SecretCombo]
    [CustomComboInfo("血壤状态", "当子弹不足时，血壤替换烈牙/爆发击/命运之环", Job.绝枪战士, Identity, 4)]
    internal sealed class BloodfestStatus : CustomCombo
    {
        public const ushort Identity = (Job.绝枪战士 << 8) ^ 0x07;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (level >= Gunbreaker.Identities.Levels.Bloodfest &&
                (actionID == Gunbreaker.Identities.Skills.GnashingFang ||
                actionID == Gunbreaker.Identities.Skills.BurstStrike ||
                actionID == Gunbreaker.Identities.Skills.FatedCircle))
            {
                if (GetJobGauge<GNBGauge>()?.Ammo == 0)
                {
                    return Gunbreaker.Identities.Skills.Bloodfest;
                }
            }

            return actionID;
        }
    }
}