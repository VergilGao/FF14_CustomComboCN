/*
 * filename: ProminenceCombo.cs
 * maintainer: VergilGao
 * description:
 *  日珥斩连击
 */

using CustomComboPlugin.Attributes;

namespace CustomComboPlugin.Combos.骑士
{
    /// <summary>
    /// 日珥斩连击
    /// </summary>
    [CustomComboInfo("日珥斩连击", "用连击替换日珥斩", Job.骑士, Identity, 3)]
    internal sealed class 日珥斩连击 : CustomCombo
    {
        public const ushort Identity = (Job.骑士 << 8) ^ 0x03;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == Identities.Skills.日珥斩)
            {
                if (comboTime > 0)
                {
                    if (lastComboMove == Identities.Skills.全蚀斩 &&
                        level >= Identities.Levels.日珥斩)
                    {
                        return Identities.Skills.日珥斩;
                    }

                    if (level >= Identities.Levels.圣环 &&
                        HasSelfEffect(Identities.Buffs.神圣魔法效果提高))
                    {
                        return Identities.Skills.圣环;
                    }
                }

                return Identities.Skills.全蚀斩;
            }

            return actionID;
        }
    }
}