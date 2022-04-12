/*
 * filename: StormsEyeCombo.cs
 * maintainer: VergilGao
 * description:
 *  暴风碎连击
 */

using CustomComboPlugin.Attributes;

using Dalamud.Game.ClientState.JobGauge.Types;

namespace CustomComboPlugin.Combos.Warrior
{
    /// <summary>
    /// 暴风碎连击
    /// </summary>
    [CustomComboInfo("暴风碎连击", "用连击替换暴风碎", Job.Warrior, Identity, 1)]
    internal sealed class StormsEyeCombo : CustomCombo
    {
        public const ushort Identity = (Job.Warrior << 8) ^ 0x01;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == Warrior.Identities.Skills.StormsEye)
            {
                if (comboTime > 0)
                {
                    if (lastComboMove == Warrior.Identities.Skills.HeavySwing &&
                        level >= Warrior.Identities.Levels.Maim)
                    {
                        return Warrior.Identities.Skills.Maim;
                    }

                    if (lastComboMove == Warrior.Identities.Skills.Maim &&
                        level >= Warrior.Identities.Levels.StormsEye)
                    {
                        return Warrior.Identities.Skills.StormsEye;
                    }
                }

                return Warrior.Identities.Skills.HeavySwing;
            }

            return actionID;
        }
    }

    /// <summary>
    /// 暴风碎兽魂量谱状态
    /// </summary>
    [SecretCombo]
    [ParentCombo(StormsEyeCombo.Identity)]
    [CustomComboInfo("暴风碎兽魂量谱状态", "兽魂溢出时，裂石飞环替换暴风碎", Job.Warrior, Identity, 2)]
    internal sealed class StormsEyeBeastStatus : CustomCombo
    {
        public const ushort Identity = (Job.Warrior << 8) ^ 0x05;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == Warrior.Identities.Skills.StormsEye)
            {
                var beast = GetJobGauge<WARGauge>();

                if (beast?.BeastGauge == 100 ||
                   (lastComboMove == Warrior.Identities.Skills.HeavySwing && beast?.BeastGauge > 90) ||
                   (lastComboMove == Warrior.Identities.Skills.Maim && beast?.BeastGauge > 90))
                {
                    // 原初之魂/裂石飞环/狂魂
                    return LevelSync(Warrior.Identities.Skills.InnerBeast);
                }
            }

            return actionID;
        }
    }

    /// <summary>
    /// 暴风碎解放状态
    /// </summary>
    [SecretCombo]
    [ParentCombo(StormsEyeCombo.Identity)]
    [CustomComboInfo("暴风碎解放状态", "原初的解放时，裂石飞环替换暴风碎", Job.Warrior, Identity, 3)]
    internal sealed class StormsEyeInnerRelease : CustomCombo
    {
        public const ushort Identity = (Job.Warrior << 8) ^ 0x10;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == Warrior.Identities.Skills.StormsEye)
            {
                var innerRelease = FindPlayerEffect(Warrior.Identities.Buffs.InnerRelease);

                if (innerRelease?.StackCount > 0)
                {
                    // 原初之魂/裂石飞环/狂魂
                    return LevelSync(Warrior.Identities.Skills.InnerBeast);
                }
            }

            return actionID;
        }
    }
}