/*
 * filename: GnashingFangContinuationStatus.cs
 * maintainer: VergilGao
 * description:
 *  烈牙-续剑状态
 */

using CustomComboPlugin.Attributes;

namespace CustomComboPlugin.Combos.Gunbreaker
{
    /// <summary>
    /// 烈牙-续剑状态
    /// </summary>
    [CustomComboInfo("烈牙-续剑状态", "续剑插入烈牙连击", Job.绝枪战士, Identity, 2)]
    internal sealed class GnashingFangContinuationStatus : CustomCombo
    {
        public const ushort Identity = (Job.绝枪战士 << 8) ^ 0x02;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == Gunbreaker.Identities.Skills.GnashingFang)
            {
                if (level >= Gunbreaker.Identities.Levels.Continuation)
                {
                    if (HasSelfEffect(Gunbreaker.Identities.Buffs.ReadyToRip))
                    {
                        return Gunbreaker.Identities.Skills.JugularRip;
                    }

                    if (HasSelfEffect(Gunbreaker.Identities.Buffs.ReadyToTear))
                    {
                        return Gunbreaker.Identities.Skills.AbdomenTear;
                    }

                    if (HasSelfEffect(Gunbreaker.Identities.Buffs.ReadyToGouge))
                    {
                        return Gunbreaker.Identities.Skills.EyeGouge;
                    }
                }

                return OriginalHook(actionID);
            }

            return actionID;
        }
    }
}