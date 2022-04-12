/*
 * filename: StormsPathCombo.cs
 * maintainer: VergilGao
 * description:
 *  暴风斩连击
 */

using CustomComboPlugin.Attributes;

using Dalamud.Game.ClientState.JobGauge.Types;

namespace CustomComboPlugin.Combos.Warrior
{
    /// <summary>
    /// 暴风斩连击
    /// </summary>
    [CustomComboInfo("暴风斩连击", "用连击替换暴风斩", Job.Warrior, Identity, 0)]
    internal sealed class StormsPathCombo : CustomCombo
    {
        public const ushort Identity = (Job.Warrior << 8) ^ 0x00;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == Warrior.Identities.Skills.StormsPath)
            {
                if (comboTime > 0)
                {
                    if (lastComboMove == Warrior.Identities.Skills.HeavySwing &&
                        level >= Warrior.Identities.Levels.Maim)
                    {
                        return Warrior.Identities.Skills.Maim;
                    }

                    if (lastComboMove == Warrior.Identities.Skills.Maim &&
                        level >= Warrior.Identities.Levels.StormsPath)
                    {
                        return Warrior.Identities.Skills.StormsPath;
                    }
                }

                return Warrior.Identities.Skills.HeavySwing;
            }

            return actionID;
        }
    }

    /// <summary>
    /// 暴风斩兽魂量谱状态
    /// </summary>
    [SecretCombo]
    [ParentCombo(StormsPathCombo.Identity)]
    [CustomComboInfo("暴风斩兽魂量谱状态", "兽魂溢出时，裂石飞环替换暴风斩", Job.Warrior, Identity, 1)]
    internal sealed class StormPathBeastStatus : CustomCombo
    {
        public const ushort Identity = (Job.Warrior << 8) ^ 0x04;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == Warrior.Identities.Skills.StormsPath)
            {
                var beast = GetJobGauge<WARGauge>();

                if (beast?.BeastGauge == 100 ||
                   (lastComboMove == Warrior.Identities.Skills.HeavySwing && beast?.BeastGauge >= 90) ||
                   (lastComboMove == Warrior.Identities.Skills.Maim && beast?.BeastGauge >= 80))
                {
                    // 原初之魂/裂石飞环/狂魂
                    return OriginalHook(Warrior.Identities.Skills.InnerBeast);
                }
            }

            return actionID;
        }
    }

    /// <summary>
    /// 暴风斩解放状态
    /// </summary>
    [SecretCombo]
    [ParentCombo(StormsPathCombo.Identity)]
    [CustomComboInfo("暴风斩解放状态", "原初的解放时，裂石飞环替换暴风斩", Job.Warrior, Identity, 2)]
    internal sealed class StormsPathInnerRelease : CustomCombo
    {
        public const ushort Identity = (Job.Warrior << 8) ^ 0x09;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == Warrior.Identities.Skills.StormsPath)
            {
                var innerRelease = FindPlayerEffect(Warrior.Identities.Buffs.InnerRelease);

                if (innerRelease?.StackCount > 0)
                {
                    // 原初之魂/裂石飞环/狂魂
                    return OriginalHook(Warrior.Identities.Skills.InnerBeast);
                }
            }

            return actionID;
        }
    }
}