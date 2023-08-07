/*
 * filename: SolidBarrelCombo.cs
 * maintainer: VergilGao
 * description:
 *  迅连斩连击
 */

using CustomComboPlugin.Attributes;

using Dalamud.Game.ClientState.JobGauge.Types;

namespace CustomComboPlugin.Combos.Gunbreaker
{
    /// <summary>
    /// 迅连斩连击
    /// </summary>
    [CustomComboInfo("迅连斩连击", "用连击替换迅连斩", Job.绝枪战士, Identity, 0)]
    internal sealed class SolidBarrelCombo : CustomCombo
    {
        public const ushort Identity = (Job.绝枪战士 << 8) ^ 0x00;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == Gunbreaker.Identities.Skills.SolidBarrel)
            {
                if (comboTime > 0)
                {
                    if (lastComboMove == Gunbreaker.Identities.Skills.BrutalShell &&
                        level >= Gunbreaker.Identities.Levels.SolidBarrel)
                    {
                        return Gunbreaker.Identities.Skills.SolidBarrel;
                    }

                    if (lastComboMove == Gunbreaker.Identities.Skills.KeenEdge &&
                        level >= Gunbreaker.Identities.Levels.BrutalShell)
                    {
                        return Gunbreaker.Identities.Skills.BrutalShell;
                    }
                }

                return Gunbreaker.Identities.Skills.KeenEdge;
            }

            return actionID;
        }
    }

    /// <summary>
    /// 迅连斩-爆发击
    /// </summary>
    [SecretCombo]
    [ParentCombo(SolidBarrelCombo.Identity)]
    [CustomComboInfo("迅连斩-爆发击", "子弹即将溢出时，爆发击替换迅连斩", Job.绝枪战士, Identity, 1)]
    internal sealed class SolidBarrelAmmoStatus : CustomCombo
    {
        public const ushort Identity = (Job.绝枪战士 << 8) ^ 0x04;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == Gunbreaker.Identities.Skills.SolidBarrel)
            {
                if (comboTime > 0)
                {
                    if (lastComboMove == Gunbreaker.Identities.Skills.BrutalShell &&
                        level >= Gunbreaker.Identities.Levels.BurstStrike)
                    {
                        var maxAmmo = level >= Gunbreaker.Identities.Levels.CartridgeCharge2 ? 3 : 2;

                        if (GetJobGauge<GNBGauge>()?.Ammo == maxAmmo)
                        {
                            return Gunbreaker.Identities.Skills.BurstStrike;
                        }
                    }
                }
            }

            return actionID;
        }
    }

    /// <summary>
    /// 迅连斩-爆发击-超高速
    /// </summary>
    [SecretCombo]
    [ParentCombo(SolidBarrelAmmoStatus.Identity)]
    [CustomComboInfo("迅连斩-爆发击-超高速", "超高速预备时超高速替换迅连斩", Job.绝枪战士, Identity, 2)]
    internal sealed class SolidBarrelEnhancedContinuation : CustomCombo
    {
        public const ushort Identity = (Job.绝枪战士 << 8) ^ 0x05;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == Gunbreaker.Identities.Skills.SolidBarrel && HasSelfEffect(Gunbreaker.Identities.Buffs.ReadyToBlast))
            {
                return Gunbreaker.Identities.Skills.EnhancedContinuation;
            }

            return actionID;
        }
    }

    /// <summary>
    /// 无情连击
    /// </summary>
    [SecretCombo]
    [ParentCombo(SolidBarrelAmmoStatus.Identity)]
    [CustomComboInfo("无情连击", "无情状态中，用优先级最高的技能替换迅连斩（你仍然需要手动插入弓形冲波和爆破领域）", Job.绝枪战士, Identity, 255)]
    internal sealed class NoMercyCombo : CustomCombo
    {
        public const ushort Identity = (Job.绝枪战士 << 8) ^ 0xff;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == Gunbreaker.Identities.Skills.SolidBarrel && HasSelfEffect(Gunbreaker.Identities.Buffs.NoMercy))
            {
                // 确保续剑触发
                if (level >= Gunbreaker.Identities.Levels.Continuation)
                {
                    if (HasSelfEffect(Gunbreaker.Identities.Buffs.ReadyToRip))
                    {
                        return Gunbreaker.Identities.Skills.JugularRip;
                    }

                    if (HasSelfEffect(Gunbreaker.Identities.Buffs.ReadyToTear))
                    {
                        return Gunbreaker.Identities.Skills.AbdomenTear;
                    }

                    if (HasSelfEffect(Gunbreaker.Identities.Buffs.ReadyToGouge))
                    {
                        return Gunbreaker.Identities.Skills.EyeGouge;
                    }

                    if (HasSelfEffect(Gunbreaker.Identities.Buffs.ReadyToBlast))
                    {
                        return Gunbreaker.Identities.Skills.EnhancedContinuation;
                    }
                }

                // 没子弹了放血壤
                if (level >= Gunbreaker.Identities.Levels.Bloodfest &&
                    !GetCooldown(Gunbreaker.Identities.Skills.Bloodfest).IsCooldown &&
                    GetJobGauge<GNBGauge>()?.Ammo == 0)
                {
                    return Gunbreaker.Identities.Skills.Bloodfest;
                }

                // 烈牙连击
                if (level >= Gunbreaker.Identities.Levels.GnashingFang &&
                    (GetJobGauge<GNBGauge>()?.Ammo >= 1 || GetCooldown(Gunbreaker.Identities.Skills.GnashingFang).IsCooldown))
                {
                    var originalGnashingFangID = OriginalHook(Gunbreaker.Identities.Skills.GnashingFang);

                    if (!GetCooldown(originalGnashingFangID).IsCooldown)
                    {
                        return originalGnashingFangID;
                    }
                }

                // 音速破
                if (level >= Gunbreaker.Identities.Levels.SonicBreak &&
                    !GetCooldown(Gunbreaker.Identities.Skills.SonicBreak).IsCooldown)
                {
                    return Gunbreaker.Identities.Skills.SonicBreak;
                }

                // 倍攻
                if (level >= Gunbreaker.Identities.Levels.DoubleDown &&
                    GetJobGauge<GNBGauge>()?.Ammo >= 2 &&
                    !GetCooldown(Gunbreaker.Identities.Skills.DoubleDown).IsCooldown)
                {
                    return Gunbreaker.Identities.Skills.DoubleDown;
                }

                // 爆发击优先级最后
                if (level >= Gunbreaker.Identities.Levels.BurstStrike &&
                    GetJobGauge<GNBGauge>()?.Ammo > 0)
                {
                    return Gunbreaker.Identities.Skills.BurstStrike;
                }
            }

            return actionID;
        }
    }
}