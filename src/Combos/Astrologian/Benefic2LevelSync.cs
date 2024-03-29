﻿/*
 * filename: Benefic2LevelSync.cs
 * maintainer: VergilGao
 * description:
 *  福星向下同步
 */

using CustomComboPlugin.Attributes;

namespace CustomComboPlugin.Combos.Astrologian
{
    [CustomComboInfo("福星同步吉星", "当等级同步到26级以下时，吉星替换福星", Job.占星术士, Identity, 0)]
    internal class Benefic2LevelSync : CustomCombo
    {
        public const ushort Identity = (Job.占星术士 << 8) ^ 0x00;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if ((actionID == Astrologian.Identities.Skills.Benefic2 && level < Astrologian.Identities.Levels.Benefic2))
            {
                return Astrologian.Identities.Skills.Benfic;
            }

            return actionID;
        }
    }
}