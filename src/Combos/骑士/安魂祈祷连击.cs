/*
 * filename: RequiescatConfiteorCombo.cs
 * maintainer: VergilGao
 * description:
 *  安魂祈祷-悔罪
 */

using CustomComboPlugin.Attributes;

namespace CustomComboPlugin.Combos.骑士;

/// <summary>
    /// 安魂祈祷连击
    /// </summary>
    [SecretCombo]
    [CustomComboInfo("安魂祈祷连击", "安魂祈祷生效中，圣灵/悔罪替换安魂祈祷", Job.骑士, Identity, 5)]
    internal sealed class 安魂祈祷连击 : CustomCombo
    {
        public const ushort Identity = (Job.骑士 << 8) ^ 0x05;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == Identities.Skills.安魂祈祷)
            {
                if (level >= Identities.Levels.悔罪)
                {
                    if (HasSelfEffect(Identities.Buffs.悔罪预备))
                    {
                        return OriginalHook(Identities.Skills.悔罪);
                    }
                }

                if(HasSelfEffect(Identities.Buffs.安魂祈祷))
                {
                    if (level >= Identities.Levels.信念之剑)
                    {
                        return OriginalHook(Identities.Skills.悔罪);
                    }
                    else
                    {
                        return Identities.Skills.圣灵;
                    }
                }

                
            }

            return actionID;
        }
    }