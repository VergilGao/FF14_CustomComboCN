/*
 * filename: AtonementCombo.cs
 * maintainer: VergilGao
 * description:
 *  王权剑-赎罪连击
 */

using CustomComboPlugin.Attributes;

namespace CustomComboPlugin.Combos.骑士
{
    /// <summary>
    /// 王权剑-赎罪连击
    /// </summary>
    [CustomComboInfo("赎罪连击", "忠义之剑生效中，赎罪替换王权剑", Job.骑士, Identity, 2)]
    internal sealed class 赎罪连击 : CustomCombo
    {
        public const ushort Identity = (Job.骑士 << 8) ^ 0x02;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == Identities.Skills.王权剑)
            {
                if (level >= Identities.Levels.圣灵 &&
                   HasSelfEffect(Identities.Buffs.神圣魔法效果提高))
                {
                    return Identities.Skills.圣灵;
                }

                if (HasSelfEffect(Identities.Buffs.忠义之剑))
                {
                    return Identities.Skills.赎罪剑;
                }
            }

            return actionID;
        }
    }
}