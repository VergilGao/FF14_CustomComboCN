/*
 * filename: StormsEyeSurgingTempestStatus.cs
 * maintainer: VergilGao
 * description:
 *  暴风碎战场风暴状态
 */

using CustomComboPlugin.Attributes;

namespace CustomComboPlugin.Combos.Warrior
{
    /// <summary>
    /// 暴风碎战场风暴状态
    /// </summary>
    [SecretCombo]
    [CustomComboInfo("战场风暴状态", "红斩不足15秒时，暴风碎替换暴风斩", Job.战士, Identity, 4)]
    internal sealed class StormsEyeSurgingTempestStatus : CustomCombo
    {
        public const ushort Identity = (Job.战士 << 8) ^ 0x06;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == Warrior.Identities.Skills.StormsPath)
            {
                if (comboTime > 0)
                {
                    if (lastComboMove == Warrior.Identities.Skills.Maim &&
                        level >= Warrior.Identities.Levels.StormsEye &&
                        !(FindPlayerEffect(Warrior.Identities.Buffs.SurgingTempest)?.RemainingTime > 15))
                    {
                        return Warrior.Identities.Skills.StormsEye;
                    }
                }
            }

            return actionID;
        }
    }
}