/*
 * filename: BrutalShellCombo.cs
 * maintainer: VergilGao
 * description:
 *  残暴弹连击
 */

using CustomComboPlugin.Attributes;

namespace CustomComboPlugin.Combos.Gunbreaker
{
    /// <summary>
    /// 残暴弹连击
    /// </summary>
    [CustomComboInfo("残暴弹连击", "连击替换残暴弹，不打迅连斩来回血（真这么高压还是跳了算了）", Job.绝枪战士, Identity, 1)]
    internal sealed class BrutalShellCombo : CustomCombo
    {
        public const ushort Identity = (Job.绝枪战士 << 8) ^ 0x01;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == Gunbreaker.Identities.Skills.BrutalShell)
            {
                if (comboTime > 0)
                {
                    if (lastComboMove == Gunbreaker.Identities.Skills.KeenEdge &&
                        level >= Gunbreaker.Identities.Levels.BrutalShell)
                    {
                        return Gunbreaker.Identities.Skills.BrutalShell;
                    }
                }

                return Gunbreaker.Identities.Skills.KeenEdge;
            }

            return actionID;
        }
    }
}