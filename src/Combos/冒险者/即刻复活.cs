/*
 * filename: SwiftRaise.cs
 * maintainer: VergilGao
 * description:
 *  即刻复活
 */

using CustomComboPlugin.Attributes;

namespace CustomComboPlugin.Combos.冒险者
{
    [CustomComboInfo("即刻复活", "当即刻咏唱可用时，即刻咏唱替换复活技能", Job.冒险者, Identity, -1)]
    internal sealed class 即刻复活 : CustomCombo
    {
        public const ushort Identity = (Job.冒险者 << 8) ^ 0x10;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if ((actionID == WhiteMage.Identities.Skills.Raise && level >= WhiteMage.Identities.Levels.Raise) || // 白魔法师
                (actionID == Arcanist.Identities.Skills.Resurrection && level >= Arcanist.Identities.Levels.Resurrection) || // 秘书双子
                (actionID == Astrologian.Identities.Skills.Ascend && level >= Astrologian.Identities.Levels.Ascend) || // 占星术士
                (actionID == RedMage.Identities.Skills.Verraise && level >= RedMage.Identities.Levels.Verraise && !HasSelfEffect(RedMage.Identities.Buffs.Dualcast)) || // 赤魔法师
                (actionID == Sage.Identities.Skills.Egeiro && level >= Sage.Identities.Levels.Egeiro) || // 贤者
                (actionID == BlueMage.Identities.Skills.AngelWhisper)) // 青魔法师
            {
                if (level >= Identities.Levels.即刻咏唱 && IsOffCooldown(Identities.Skills.即刻咏唱))
                {
                    return Identities.Skills.即刻咏唱;
                }
            }

            return actionID;
        }
    }
}