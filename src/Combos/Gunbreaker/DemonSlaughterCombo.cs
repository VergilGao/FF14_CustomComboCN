/*
 * filename: DemonSlaughterCombo.cs
 * maintainer: VergilGao
 * description:
 *  恶魔杀连击
 */

using CustomComboPlugin.Attributes;

using Dalamud.Game.ClientState.JobGauge.Types;

namespace CustomComboPlugin.Combos.Gunbreaker
{
    /// <summary>
    /// 恶魔杀连击
    /// </summary>
    [CustomComboInfo("恶魔杀连击", "连击替换恶魔杀", Job.绝枪战士, Identity, 3)]
    internal sealed class DemonSlaughterCombo : CustomCombo
    {
        public const ushort Identity = (Job.绝枪战士 << 8) ^ 0x03;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == Gunbreaker.Identities.Skills.DemonSlaughter)
            {
                if (comboTime > 0)
                {
                    if (lastComboMove == Gunbreaker.Identities.Skills.DemonSlice &&
                        level >= Gunbreaker.Identities.Levels.DemonSlaughter)
                    {
                        return Gunbreaker.Identities.Skills.DemonSlaughter;
                    }
                }

                return Gunbreaker.Identities.Skills.DemonSlice;
            }

            return actionID;
        }
    }

    /// <summary>
    /// 恶魔杀-命运之环
    /// </summary>
    [SecretCombo]
    [ParentCombo(DemonSlaughterCombo.Identity)]
    [CustomComboInfo("恶魔杀-命运之环", "子弹即将溢出时，命运之环替换恶魔杀", Job.绝枪战士, Identity, 4)]
    internal sealed class FatedCircleAmmoStatus : CustomCombo
    {
        public const ushort Identity = (Job.绝枪战士 << 8) ^ 0x06;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == Gunbreaker.Identities.Skills.DemonSlaughter)
            {
                var gauge = GetJobGauge<GNBGauge>();
                var maxAmmo = level >= Gunbreaker.Identities.Levels.CartridgeCharge2 ? 3 : 2;

                if (gauge?.Ammo == maxAmmo && level >= Gunbreaker.Identities.Levels.FatedCircle)
                {
                    return Gunbreaker.Identities.Skills.FatedCircle;
                }
            }

            return actionID;
        }
    }
}