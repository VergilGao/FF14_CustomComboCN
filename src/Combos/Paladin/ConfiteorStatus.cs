/*
 * filename: ConfiteorStatus.cs
 * maintainer: VergilGao
 * description:
 *  悔罪替换圣灵/圣环
 */

using CustomComboPlugin.Attributes;

namespace CustomComboPlugin.Combos.Paladin
{
    /// <summary>
    /// 悔罪替换圣灵/圣环
    /// </summary>
    [SecretCombo]
    [CustomComboInfo("悔罪替换圣灵/圣环", "当玩家蓝量小于1000或安魂祈祷剩余时间小于2.5秒时，用悔罪替换圣灵/圣环", Job.Paladin, Identity, 7)]
    internal sealed class ConfiteorStatus : CustomCombo
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

                    if (requiescat != null && requiescat.RemainingTime > 0 && requiescat.StackCount > 1)
                    {
                        if (LocalPlayer?.CurrentMp < 1000 || (requiescat.RemainingTime <= GetCooldown(Paladin.Identities.Skills.Confiteor).CooldownTotal))
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