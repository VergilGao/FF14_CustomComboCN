/*
 * filename: FlourishingStarfallStatus.cs
 * maintainer: VergilGao
 * description:
 *  流星舞状态
 */

using CustomComboPlugin.Attributes;

namespace CustomComboPlugin.Combos.Dancer
{
    /// <summary>
    /// 流星舞状态
    /// </summary>
    [SecretCombo]
    [CustomComboInfo("流星舞状态", "流星舞预备状态时，流星舞替换进攻之探戈", Job.舞者, Identity, 3)]
    internal sealed class FlourishingStarfallStatus : CustomCombo
    {
        public const ushort Identity = (Job.舞者 << 8) ^ 0x05;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == Dancer.Identities.Skills.Devilment)
            {
                if (level >= Dancer.Identities.Levels.StarfallDance && HasSelfEffect(Dancer.Identities.Buffs.FlourishingStarfall))
                {
                    return Dancer.Identities.Skills.StarfallDance;
                }
            }

            return actionID;
        }
    }
}