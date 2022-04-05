/*
 * filename: ConfiteorRequiescatCombo.cs
 * maintainer: VergilGao
 * description:
 *  悔罪-安魂祈祷
 */

using CustomComboPlugin.Attributes;

namespace CustomComboPlugin.Combos.Paladin
{
    /// <summary>
    /// 悔罪-安魂祈祷
    /// </summary>
    [SecretCombo]
    [ConflictCombo(RequiescatConfiteorCombo.Identity)]
    [CustomComboInfo("悔罪-安魂祈祷", "不在悔罪连击时，安魂祈祷替换悔罪", Job.Paladin, Identity, 6)]
    internal sealed class ConfiteorRequiescatCombo : CustomCombo
    {
        public const ushort Identity = (Job.Paladin << 8) ^ 0x06;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == Paladin.Identities.Skills.Confiteor)
            {
                if (comboTime > 0)
                {
                    if (lastComboMove == Paladin.Identities.Skills.BladeOfTruth ||
                        lastComboMove == Paladin.Identities.Skills.BladeOfFaith ||
                        lastComboMove == Paladin.Identities.Skills.Confiteor)
                    {
                        return LevelSync(Paladin.Identities.Skills.Confiteor);
                    }
                }

                if (level > Paladin.Identities.Levels.Confiteor)
                {
                    if (HasSelfEffect(Paladin.Identities.Buffs.Requiescat))
                    {
                        return Paladin.Identities.Skills.Confiteor;
                    }
                }

                return Paladin.Identities.Skills.Requiescat;
            }

            return actionID;
        }
    }
}