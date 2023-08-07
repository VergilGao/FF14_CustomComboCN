/*
 * filename: RoyalAuthorityCombo.cs
 * maintainer: VergilGao
 * description:
 *  王权剑连击
 */

using CustomComboPlugin.Attributes;

namespace CustomComboPlugin.Combos.骑士
{
    /// <summary>
    /// 王权剑连击
    /// </summary>
    [CustomComboInfo("王权剑连击", "用连击替换战女神之怒/王权剑", Job.骑士, Identity, 0)]
    internal sealed class 王权剑连击 : CustomCombo
    {
        public const ushort Identity = (Job.骑士 << 8) ^ 0x00;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == Identities.Skills.战女神之怒 ||
                actionID == Identities.Skills.王权剑)
            {
                if (comboTime > 0)
                {
                    if (lastComboMove == Identities.Skills.暴乱剑 &&
                        level >= Identities.Levels.战女神之怒)
                    {
                        // 战女神之怒/王权剑
                        return OriginalHook(Identities.Skills.战女神之怒);
                    }

                    if (lastComboMove == Identities.Skills.先锋剑 &&
                        level >= Identities.Levels.暴乱剑)
                    {
                        return Identities.Skills.暴乱剑;
                    }
                }

                return Identities.Skills.先锋剑;
            }

            return actionID;
        }
    }
}