/*
 * filename: FanDance.cs
 * maintainer: VergilGao
 * description:
 *  扇舞状态
 */

using CustomComboPlugin.Attributes;

namespace CustomComboPlugin.Combos.Dancer
{
    /// <summary>
    /// 扇舞状态
    /// </summary>
    [CustomComboInfo("扇舞状态", "扇舞·终预备/扇舞·急预备时，替换扇舞·序/扇舞·破", Job.舞者, Identity, 2)]
    internal sealed class FanDance : CustomCombo
    {
        public const ushort Identity = (Job.舞者 << 8) ^ 0x02;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == Dancer.Identities.Skills.FanDance1 || actionID == Dancer.Identities.Skills.FanDance2)
            {
                if (level >= Dancer.Identities.Levels.FanDance4 && HasSelfEffect(Dancer.Identities.Buffs.FourfoldFanDance))
                {
                    return Dancer.Identities.Skills.FanDance4;
                }

                if (level >= Dancer.Identities.Levels.FanDance3 && HasSelfEffect(Dancer.Identities.Buffs.ThreefoldFanDance))
                {
                    return Dancer.Identities.Skills.FanDance3;
                }
            }

            return actionID;
        }
    }
}