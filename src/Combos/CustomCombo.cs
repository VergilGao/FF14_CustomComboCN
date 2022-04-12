/*
 * filename: CustomCombo.cs
 * maintainer: VergilGao
 * description:
 *  自定义连击的基类，提供了自定义连击的基础功能
 */

using Dalamud.Game.ClientState.JobGauge.Types;
using Dalamud.Game.ClientState.Objects.SubKinds;
using Dalamud.Game.ClientState.Objects.Types;
using Dalamud.Game.ClientState.Statuses;

namespace CustomComboPlugin.Combos
{
    internal abstract class CustomCombo
    {
        public byte JobID { get; private set; }
        public ushort ComboID { get; private set; }
        public int Order { get; private set; }

        public bool TryInvoke(uint actionID, byte level, uint lastComboMove, float comboTime, out uint newActionID)
        {
            newActionID = 0;

            if (!IsEnabled(ComboID))
            {
                return false;
            }

            var classJobID = LocalPlayer!.ClassJob.Id;

            if (JobID != Job.Adventurer && JobID != classJobID)
            {
                return false;
            }

            var resultingActionID = Invoke(actionID, lastComboMove, comboTime, level);

            if (resultingActionID == 0 || actionID == resultingActionID)
            {
                return false;
            }

            newActionID = resultingActionID;
            return true;
        }

        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="actionID">技能ID</param>
        /// <param name="lastComboMove"></param>
        /// <param name="comboTime"></param>
        /// <param name="level">人物等级</param>
        /// <returns>下一个技能ID</returns>
        protected abstract uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level);

        #region Helper Methods

        /// <summary>
        /// 玩家
        /// </summary>
        protected static PlayerCharacter? LocalPlayer => DalamudService.ClientState.LocalPlayer;

        /// <summary>
        /// combo是否启用
        /// </summary>
        /// <param name="comboID">combo ID</param>
        /// <returns>如果combo启用，返回true</returns>
        protected static bool IsEnabled(ushort comboID) => PluginService.Configuration.IsEnabled(comboID);

        /// <summary>
        /// 技能是否结束CD
        /// </summary>
        /// <param name="actionID">技能ID</param>
        /// <returns>如果技能已经CD完成，返回true</returns>
        protected static bool IsOffCooldown(uint actionID) => !GetCooldown(actionID).IsCooldown;

        /// <summary>
        /// 获取技能的CD数据
        /// </summary>
        /// <param name="actionID">技能ID</param>
        /// <returns>技能的CD数据</returns>
        protected static CooldownData GetCooldown(uint actionID) => PluginService.ComboCache.GetCooldown(actionID);

        /// <summary>
        /// 获取技能当前等级的ID
        /// </summary>
        /// <param name="actionID">技能ID</param>
        /// <returns>技能当前等级的ID</returns>
        protected static uint LevelSync(uint actionID) => PluginService.ComboManager.OriginalHook(actionID);

        /// <summary>
        /// 获取职业量表
        /// </summary>
        /// <typeparam name="TJobGauge">职业量表的类型</typeparam>
        /// <returns>职业量表</returns>
        protected static TJobGauge GetJobGauge<TJobGauge>() where TJobGauge : JobGaugeBase
            => PluginService.ComboCache.GetJobGauge<TJobGauge>();

        /// <summary>
        /// 获取玩家是否对自己施加了某种Effect
        /// </summary>
        /// <param name="effectID">EffectID</param>
        /// <returns>如果玩家对自己施加了此Effect，返回true</returns>
        protected static bool HasSelfEffect(ushort effectID) => FindPlayerEffect(effectID) is not null;

        /// <summary>
        /// 获取玩家对自己施加的Effect
        /// </summary>
        /// <param name="effectID">EffectID</param>
        /// <returns>获取到的Effect对应的Status</returns>
        protected static Status? FindPlayerEffect(ushort effectID) => FindEffect(effectID, LocalPlayer, LocalPlayer?.ObjectId);

        /// <summary>
        /// 获取玩家自身对目标GameObject施加的特定Effect
        /// </summary>
        /// <param name="effectID">EffectID</param>
        /// <param name="gameObject">目标GameObject</param>
        /// <param name="sourceID">Effect来源ID</param>
        /// <returns>获取到的Effect对应的Status</returns>
        protected static Status? FindEffectToEnemy(ushort effectID, GameObject? gameObject)
            => PluginService.ComboCache.GetStatus(effectID, gameObject, LocalPlayer?.ObjectId);

        /// <summary>
        /// 获取目标GameObject的特定Effect
        /// </summary>
        /// <param name="effectID">EffectID</param>
        /// <param name="gameObject">目标GameObject</param>
        /// <param name="sourceID">Effect来源ID</param>
        /// <returns>获取到的Effect对应的Status</returns>
        protected static Status? FindEffect(ushort effectID, GameObject? gameObject, uint? sourceID)
            => PluginService.ComboCache.GetStatus(effectID, gameObject, sourceID);

        /// <summary>
        /// 获取玩家的宠物是否处于同行状态
        /// </summary>
        /// <returns>如果宠物处于同行状态，返回true</returns>
        protected static bool HasPetPresent() => DalamudService.BuddyList.PetBuddyPresent;

        /// <summary>
        /// 获取当前玩家的目标
        /// </summary>
        protected static GameObject? CurrentTarget => DalamudService.TargetManager.Target;

        /// <summary>
        /// 获取当前玩家的目标
        /// </summary>
        protected static GameObject? SelectedTarget => DalamudService.TargetManager.SoftTarget ?? DalamudService.TargetManager.Target;

        #endregion Helper Methods
    }
}