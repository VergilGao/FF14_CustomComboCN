/*
 * filename: MythrilTempestCombo.cs
 * maintainer: VergilGao
 * description:
 *  秘银暴风连击
 */

using CustomComboPlugin.Attributes;

using Dalamud.Game.ClientState.JobGauge.Types;

namespace CustomComboPlugin.Combos.Warrior
{
    /// <summary>
    /// 秘银暴风连击
    /// </summary>
    [ConflictCombo(Warrior.OverpowerCombo.Identity)]
    [CustomComboInfo("秘银暴风连击", "用连击替换秘银暴风", Job.战士, Identity, 2)]
    internal sealed class MythrilTempestCombo : CustomCombo
    {
        public const ushort Identity = (Job.战士 << 8) ^ 0x02;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == Warrior.Identities.Skills.MythrilTempest)
            {
                if (comboTime > 0)
                {
                    if (lastComboMove == Warrior.Identities.Skills.Overpower &&
                        level >= Warrior.Identities.Levels.MythrilTempest)
                    {
                        return Warrior.Identities.Skills.MythrilTempest;
                    }
                }

                return Warrior.Identities.Skills.Overpower;
            }

            return actionID;
        }
    }

    /// <summary>
    /// 秘银暴风兽魂量谱状态
    /// </summary>
    [SecretCombo]
    [ParentCombo(MythrilTempestCombo.Identity)]
    [CustomComboInfo("秘银暴风兽魂量谱状态", "兽魂溢出时，地毁人亡替换秘银暴风", Job.战士, Identity, 3)]
    internal sealed class MythrilTempestBeastStatus : CustomCombo
    {
        public const ushort Identity = (Job.战士 << 8) ^ 0x07;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == Warrior.Identities.Skills.MythrilTempest)
            {
                var beast = GetJobGauge<WARGauge>();

                if (level >= Warrior.Identities.Skills.SteelCyclone &&
                    (beast?.BeastGauge == 100 ||
                    (lastComboMove == Warrior.Identities.Skills.Overpower && beast?.BeastGauge > 80)))
                {
                    // 钢铁旋风/地毁人亡/混沌旋风
                    return OriginalHook(Warrior.Identities.Skills.SteelCyclone);
                }
            }

            return actionID;
        }
    }

    /// <summary>
    /// 秘银暴风解放状态
    /// </summary>
    [SecretCombo]
    [ParentCombo(MythrilTempestCombo.Identity)]
    [CustomComboInfo("秘银暴风解放状态", "原初的解放时，裂石飞环替换秘银暴风", Job.战士, Identity, 4)]
    internal sealed class MythrilTempestInnerRelease : CustomCombo
    {
        public const ushort Identity = (Job.战士 << 8) ^ 0x11;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == Warrior.Identities.Skills.MythrilTempest)
            {
                var innerRelease = FindPlayerEffect(Warrior.Identities.Buffs.InnerRelease);

                if (innerRelease?.StackCount > 0)
                {
                    // 原初之魂/裂石飞环/狂魂
                    return OriginalHook(Warrior.Identities.Skills.SteelCyclone);
                }
            }

            return actionID;
        }
    }
}