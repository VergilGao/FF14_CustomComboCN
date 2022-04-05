/*
 * filename: HolyConfiteorCombo.cs
 * maintainer: VergilGao
 * description:
 *  蓝量不足时悔罪替换圣灵/圣环
 */

using CustomComboPlugin.Attributes;

namespace CustomComboPlugin.Combos.Paladin
{
    /// <summary>
    /// 蓝量不足时悔罪替换圣灵/圣环
    /// </summary>
    [SecretCombo]
    [CustomComboInfo("蓝量不足时悔罪替换圣灵/圣环", "当安魂祈祷层数大于2并且玩家蓝量小于2000或安魂祈祷层数等于2并且玩家蓝量小于1400时，用悔罪替换圣灵/圣环", Job.Paladin, Identity, 7)]
    internal sealed class ConfiteorByMana : CustomCombo
    {
        public const ushort Identity = (Job.Paladin << 8) ^ 0x07;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == Paladin.Identities.Skills.HolySpirit ||
                actionID == Paladin.Identities.Skills.HolyCircle)
            {
                if (level > Paladin.Identities.Levels.Confiteor)
                {
                    var requiescat = FindPlayerEffect(Paladin.Identities.Buffs.Requiescat);

                    if (requiescat != null)
                    {
                        if ((requiescat.StackCount > 2 && LocalPlayer?.CurrentMp < 2000) ||
                            (requiescat.StackCount == 2 && LocalPlayer?.CurrentMp < 1400))
                        {
                            return Paladin.Identities.Skills.Confiteor;
                        }
                    }
                }
            }

            return actionID;
        }
    }
}