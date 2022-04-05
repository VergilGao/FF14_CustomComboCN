/*
 * filename: HolyConfiteorCombo.cs
 * maintainer: VergilGao
 * description:
 *  圣灵/圣环-悔罪
 */

using CustomComboPlugin.Attributes;

namespace CustomComboPlugin.Combos.Paladin
{
    /// <summary>
    /// 圣灵/圣环-悔罪
    /// </summary>
    [SecretCombo]
    [CustomComboInfo("圣灵/圣环-悔罪连击", "在安魂祈祷最后一层时悔罪替换圣灵/圣环", Job.Paladin, Identity, 4)]
    internal sealed class HolyConfiteorCombo : CustomCombo
    {
        public const ushort Identity = (Job.Paladin << 8) ^ 0x04;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == Paladin.Identities.Skills.HolySpirit ||
                actionID == Paladin.Identities.Skills.HolyCircle)
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
                    var requiescat = FindPlayerEffect(Paladin.Identities.Buffs.Requiescat);

                    if (requiescat != null && (requiescat.StackCount == 1))
                    {
                        return Paladin.Identities.Skills.Confiteor;
                    }
                }
            }

            return actionID;
        }
    }
}