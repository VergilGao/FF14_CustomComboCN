/*
 * filename: RequiescatConfiteorCombo.cs
 * maintainer: VergilGao
 * description:
 *  安魂祈祷-悔罪
 */

using CustomComboPlugin.Attributes;

namespace CustomComboPlugin.Combos.Paladin
{
    /// <summary>
    /// 安魂祈祷-悔罪
    /// </summary>
    [SecretCombo]
    [ConflictCombo(ConfiteorRequiescatCombo.Identity)]
    [CustomComboInfo("安魂祈祷-悔罪", "安魂祈祷生效中，悔罪替换安魂祈祷", Job.Paladin, Identity, 5)]
    internal sealed class RequiescatConfiteorCombo : CustomCombo
    {
        public const ushort Identity = (Job.Paladin << 8) ^ 0x05;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == Paladin.Identities.Skills.Requiescat)
            {
                if (comboTime > 0)
                {
                    if (lastComboMove == Paladin.Identities.Skills.BladeOfTruth ||
                        lastComboMove == Paladin.Identities.Skills.BladeOfFaith ||
                        lastComboMove == Paladin.Identities.Skills.Confiteor)
                    {
                        return OriginalHook(Paladin.Identities.Skills.Confiteor);
                    }
                }

                if (level > Paladin.Identities.Levels.Confiteor)
                {
                    if (HasSelfEffect(Paladin.Identities.Buffs.Requiescat))
                    {
                        return Paladin.Identities.Skills.Confiteor;
                    }
                }
            }

            return actionID;
        }
    }
}