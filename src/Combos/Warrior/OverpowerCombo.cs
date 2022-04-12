/*
 * filename: OverpowerCombo.cs
 * maintainer: VergilGao
 * description:
 *  超压斧连击
 */

using CustomComboPlugin.Attributes;

using Dalamud.Game.ClientState.JobGauge.Types;

namespace CustomComboPlugin.Combos.Warrior
{
    /// <summary>
    /// 超压斧连击
    /// </summary>
    [ConflictCombo(Warrior.MythrilTempestCombo.Identity)]
    [CustomComboInfo("超压斧连击", "用连击替换超压斧，这样你就可以单独释放秘银爆发了", Job.Warrior, Identity, 3)]
    internal sealed class OverpowerCombo : CustomCombo
    {
        public const ushort Identity = (Job.Warrior << 8) ^ 0x03;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == Warrior.Identities.Skills.Overpower)
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
    ///超压斧兽魂量谱状态
    /// </summary>
    [SecretCombo]
    [ParentCombo(OverpowerCombo.Identity)]
    [CustomComboInfo("超压斧兽魂量谱状态", "兽魂溢出时，地毁人亡替换超压斧", Job.Warrior, Identity, 4)]
    internal sealed class OverpowerBeastStatus : CustomCombo
    {
        public const ushort Identity = (Job.Warrior << 8) ^ 0x08;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == Warrior.Identities.Skills.Overpower)
            {
                var beast = GetJobGauge<WARGauge>();

                if (level >= Warrior.Identities.Skills.SteelCyclone &&
                    (beast?.BeastGauge == 100 ||
                    (lastComboMove == Warrior.Identities.Skills.Overpower && beast?.BeastGauge > 80)))
                {
                    // 钢铁旋风/地毁人亡/混沌旋风
                    return LevelSync(Warrior.Identities.Skills.SteelCyclone);
                }
            }

            return actionID;
        }
    }

    /// <summary>
    /// 超压斧解放状态
    /// </summary>
    [SecretCombo]
    [ParentCombo(OverpowerCombo.Identity)]
    [CustomComboInfo("超压斧解放状态", "原初的解放时，裂石飞环替换超压斧", Job.Warrior, Identity, 5)]
    internal sealed class OverpowerInnerRelease : CustomCombo
    {
        public const ushort Identity = (Job.Warrior << 8) ^ 0x12;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == Warrior.Identities.Skills.Overpower)
            {
                var innerRelease = FindPlayerEffect(Warrior.Identities.Buffs.InnerRelease);

                if (innerRelease?.StackCount > 0)
                {
                    // 原初之魂/裂石飞环/狂魂
                    return LevelSync(Warrior.Identities.Skills.SteelCyclone);
                }
            }

            return actionID;
        }
    }
}