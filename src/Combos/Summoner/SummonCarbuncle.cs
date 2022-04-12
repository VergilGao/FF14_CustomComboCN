/*
 * filename: SummonCarbuncle.cs
 * maintainer: VergilGao
 * description:
 *  以太蓄能/龙神召唤/不死鸟召唤替换宝石兽召唤
 */

using CustomComboPlugin.Attributes;

namespace CustomComboPlugin.Combos.Summoner
{
    [CustomComboInfo("以太蓄能/龙神召唤/不死鸟召唤替换宝石兽召唤", "当宝石兽随行时，以太蓄能/龙神召唤/不死鸟召唤替换宝石兽召唤", Job.Summoner, Identity, 2)]
    internal sealed class SummonCarbuncle : CustomCombo
    {
        public const ushort Identity = (Job.Summoner << 8) ^ 0x02;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == Summoner.Identities.Skills.SummonCarbuncle)
            {
                if (level >= Summoner.Identities.Levels.Gemshine && HasPetPresent())
                {
                    return OriginalHook(Summoner.Identities.Skills.Gemshine);
                }
            }

            return actionID;
        }
    }
}