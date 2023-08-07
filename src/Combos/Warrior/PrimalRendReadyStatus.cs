/*
 * filename: PrimalRendReadyStatus.cs
 * maintainer: VergilGao
 * description:
 *  蛮荒崩裂预备状态
 */

using CustomComboPlugin.Attributes;

namespace CustomComboPlugin.Combos.Warrior
{
    /// <summary>
    /// 蛮荒崩裂预备状态
    /// </summary>
    [CustomComboInfo("蛮荒崩裂预备状态", "蛮荒崩裂预备状态时，蛮荒崩裂替换解放", Job.战士, Identity, 5)]
    internal sealed class PrimalRendReadyStatus : CustomCombo
    {
        public const ushort Identity = (Job.战士 << 8) ^ 0x13;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == Warrior.Identities.Skills.Berserk ||
                actionID == Warrior.Identities.Skills.InnerRelease)
            {
                if (FindPlayerEffect(Warrior.Identities.Buffs.PrimalRendReady) is not null)
                {
                    return Warrior.Identities.Skills.PrimalRend;
                }
            }

            return actionID;
        }
    }
}