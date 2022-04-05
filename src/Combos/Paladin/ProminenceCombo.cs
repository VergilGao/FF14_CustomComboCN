/*
 * filename: ProminenceCombo.cs
 * maintainer: VergilGao
 * description:
 *  日珥斩连击
 */

using CustomComboPlugin.Attributes;

namespace CustomComboPlugin.Combos.Paladin
{
    /// <summary>
    /// 日珥斩连击
    /// </summary>
    [CustomComboInfo("日珥斩连击", "用连击替换日珥斩", Job.Paladin, Identity, 3)]
    internal sealed class ProminenceCombo : CustomCombo
    {
        public const ushort Identity = (Job.Paladin << 8) ^ 0x03;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == Paladin.Identities.Skills.Prominence)
            {
                if (comboTime > 0)
                {
                    if (lastComboMove == Paladin.Identities.Skills.TotalEclipse &&
                        level >= Paladin.Identities.Levels.Prominence)
                    {
                        return Paladin.Identities.Skills.Prominence;
                    }
                }

                return Paladin.Identities.Skills.TotalEclipse;
            }

            return actionID;
        }
    }
}