﻿/*
 * filename: Cure2LevelSync.cs
 * maintainer: VergilGao
 * description:
 *  救疗向下同步
 */

using CustomComboPlugin.Attributes;

namespace CustomComboPlugin.Combos.WhiteMage
{
    [CustomComboInfo("救疗同步治疗", "当等级同步到30级以下时，治疗替换救疗", Job.白魔法师, Identity, 0)]
    internal class Cure2LevelSync : CustomCombo
    {
        public const ushort Identity = (Job.白魔法师 << 8) ^ 0x00;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if ((actionID == WhiteMage.Identities.Skills.Cure2 && level < WhiteMage.Identities.Levels.Cure2))
            {
                return WhiteMage.Identities.Skills.Cure;
            }

            return actionID;
        }
    }
}