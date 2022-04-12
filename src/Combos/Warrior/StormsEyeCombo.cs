/*
 * filename: StormsEyeCombo.cs
 * maintainer: VergilGao
 * description:
 *  暴风碎连击
 */

using CustomComboPlugin.Attributes;

namespace CustomComboPlugin.Combos.Warrior
{
    /// <summary>
    /// 暴风碎连击
    /// </summary>
    [CustomComboInfo("暴风碎连击", "用连击替换暴风碎", Job.Warrior, Identity, 1)]
    internal sealed class StormsEyeCombo : CustomCombo
    {
        public const ushort Identity = (Job.Warrior << 8) ^ 0x01;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == Warrior.Identities.Skills.StormsEye)
            {
                if (comboTime > 0)
                {
                    if (lastComboMove == Warrior.Identities.Skills.HeavySwing &&
                        level >= Warrior.Identities.Levels.Maim)
                    {
                        return Warrior.Identities.Skills.Maim;
                    }

                    if (lastComboMove == Warrior.Identities.Skills.Maim &&
                        level >= Warrior.Identities.Levels.StormsEye)
                    {
                        return Warrior.Identities.Skills.StormsEye;
                    }
                }

                return Warrior.Identities.Skills.HeavySwing;
            }

            return actionID;
        }
    }
}