/*
 * filename: EnhancedContinuationStatus.cs
 * maintainer: VergilGao
 * description:
 *  超高速替换爆发击
 */

using CustomComboPlugin.Attributes;

namespace CustomComboPlugin.Combos.Gunbreaker
{
    /// <summary>
    /// 超高速替换爆发击
    /// </summary>
    [SecretCombo]
    [CustomComboInfo("超高速替换爆发击", "当超高速准备时，超高速替换爆发击", Job.Gunbreaker, Identity, 5)]
    internal sealed class EnhancedContinuationStatus : CustomCombo
    {
        public const ushort Identity = (Job.Gunbreaker << 8) ^ 0x08;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == Gunbreaker.Identities.Skills.BurstStrike && HasSelfEffect(Gunbreaker.Identities.Buffs.ReadyToBlast))
            {
                return Gunbreaker.Identities.Skills.EnhancedContinuation;
            }

            return actionID;
        }
    }
}