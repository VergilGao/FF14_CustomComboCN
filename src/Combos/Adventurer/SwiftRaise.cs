/*
 * filename: SwiftRaise.cs
 * maintainer: VergilGao
 * description:
 *  即刻复活
 */

using CustomComboPlugin.Attributes;

namespace CustomComboPlugin.Combos.Adventurer
{
    /// <summary>
    /// 即刻复活
    /// </summary>
    [CustomComboInfo("即刻复活", "当即刻咏唱可用时，即刻咏唱替换复活技能", Job.Adventurer, Identity, -1)]
    internal sealed class SwiftRaise : CustomCombo
    {
        public const ushort Identity = (Job.Adventurer << 8) ^ 0x10;

        protected override uint Invoke(uint actionId, uint lastComboMove, float comboTime, byte level)
        {
            if ((actionId == WhiteMage.Identities.Skills.Raise && level >= WhiteMage.Identities.Levels.Raise) ||
                (actionId == Summoner.Identities.Skills.Resurrection && level >= Summoner.Identities.Levels.Resurrection) ||
                (actionId == Astrologian.Identities.Skills.Ascend && level >= Astrologian.Identities.Levels.Ascend))
            {
                if (level >= Adventurer.Identities.Levels.Swiftcast && IsOffCooldown(Adventurer.Identities.Skills.Swiftcast))
                {
                    return Adventurer.Identities.Skills.Swiftcast;
                }
            }

            return actionId;
        }
    }
}