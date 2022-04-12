/*
 * filename: StormsPathCombo.cs
 * maintainer: VergilGao
 * description:
 *  暴风斩连击
 */

using CustomComboPlugin.Attributes;

namespace CustomComboPlugin.Combos.Warrior
{
    /// <summary>
    /// 暴风斩连击
    /// </summary>
    [CustomComboInfo("暴风斩连击", "用连击替换暴风斩", Job.Warrior, Identity, 0)]
    internal sealed class StormsPathCombo : CustomCombo
    {
        public const ushort Identity = (Job.Warrior << 8) ^ 0x00;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == Warrior.Identities.Skills.StormsPath)
            {
                if (comboTime > 0)
                {
                    if (lastComboMove == Warrior.Identities.Skills.HeavySwing &&
                        level >= Warrior.Identities.Levels.Maim)
                    {
                        return Warrior.Identities.Skills.Maim;
                    }

                    if (lastComboMove == Warrior.Identities.Skills.Maim &&
                        level >= Warrior.Identities.Levels.StormsPath)
                    {
                        return Warrior.Identities.Skills.StormsPath;
                    }
                }

                return Warrior.Identities.Skills.HeavySwing;
            }

            return actionID;
        }
    }
}