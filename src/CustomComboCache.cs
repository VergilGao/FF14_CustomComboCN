/*
 * filename: CustomComboCache.cs
 * maintainer: VergilGao
 * description:
 *  自定义连击的缓存
 */

using System;
using System.Collections.Generic;

using Dalamud.Game;
using Dalamud.Game.ClientState.JobGauge.Types;
using Dalamud.Game.ClientState.Objects.Types;

using FFXIVClientStructs.FFXIV.Client.Game;

using Lumina.Excel;

using Action = Lumina.Excel.GeneratedSheets.Action;
using Status = Dalamud.Game.ClientState.Statuses.Status;

namespace CustomComboPlugin
{
    internal sealed class CustomComboCache : IDisposable
    {
        private const uint InvalidObjectID = 0xE000_0000;

        // 每次 Framework Update 都令其过期
        private readonly Dictionary<(uint StatusId, uint? TargetId, uint? SourceId), Status?> statusCache = new(); // 状态缓存

        private readonly Dictionary<uint, CooldownData> cooldownCache = new(); // 冷却数据缓存

        // 无需过期
        private readonly Dictionary<uint, byte> cooldownGroupCache = new();

        private readonly Dictionary<(uint ActionID, uint ClassJobID, byte Level), (ushort CurrentMax, ushort Max)> chargesCache = new(); // 技能充能次数的缓存

        private readonly Dictionary<Type, JobGaugeBase> jobGaugeCache = new(); // 职业量表

        private readonly ExcelSheet<Action> actionSheet; // 技能的数据表

        public CustomComboCache()
        {
            DalamudService.Framework.Update += OnFrameworkUpdate;
            actionSheet = DalamudService.DataManager.GetExcelSheet<Action>()!;
        }

        /// <summary>
        /// 获取指定技能的CD数据
        /// </summary>
        /// <param name="actionID">技能ID</param>
        /// <returns>CD数据</returns>
        internal unsafe CooldownData GetCooldown(uint actionID)
        {
            if (cooldownCache.TryGetValue(actionID, out var found))
            {
                return found;
            }

            var actionManager = ActionManager.Instance();
            if (actionManager == null)
            {
                cooldownCache[actionID] = default;
            }

            var cooldownGroup = GetCooldownGroup(actionID);

            var cooldownPtr = actionManager->GetRecastGroupDetail(cooldownGroup - 1);
            cooldownPtr->ActionID = actionID;

            return cooldownCache[actionID] = *(CooldownData*)cooldownPtr;
        }

        /// <summary>
        /// 获取指定技能的最大充能次数
        /// </summary>
        /// <param name="actionID">技能ID</param>
        /// <returns>技能当前等级和最大等级时的充能次数</returns>
        internal unsafe (ushort Current, ushort Max) GetMaxCharges(uint actionID)
        {
            var player = DalamudService.ClientState.LocalPlayer;
            if (player == null)
            {
                return (0, 0);
            }

            var job = player.ClassJob.Id;
            var level = player.Level;
            if (job == 0 || level == 0)
            {
                return (0, 0);
            }

            var key = (actionID, job, level);
            if (chargesCache.TryGetValue(key, out var found))
            {
                return found;
            }

            var cur = ActionManager.GetMaxCharges(actionID, 0);
            var max = ActionManager.GetMaxCharges(actionID, 90);
            return chargesCache[key] = (cur, max);
        }

        private byte GetCooldownGroup(uint actionID)
        {
            if (cooldownGroupCache.TryGetValue(actionID, out var cooldownGroup))
                return cooldownGroup;

            var row = actionSheet.GetRow(actionID);

            return cooldownGroupCache[actionID] = row!.CooldownGroup;
        }

        /// <summary>
        /// 获取职业量表
        /// </summary>
        /// <typeparam name="TJobGauge">职业量表的类型</typeparam>
        /// <returns>职业量表</returns>
        public TJobGauge GetJobGauge<TJobGauge>() where TJobGauge : JobGaugeBase
        {
            if (!jobGaugeCache.TryGetValue(typeof(TJobGauge), out var gauge))
            {
                gauge = jobGaugeCache[typeof(TJobGauge)] = DalamudService.JobGauges.Get<TJobGauge>();
            }

            return (TJobGauge)gauge;
        }

        public Status? GetStatus(uint statusId, GameObject? gameObject, uint? sourceId)
        {
            var key = (statusId, gameObject?.ObjectId, sourceId);
            if (statusCache.TryGetValue(key, out var found))
            {
                return found;
            }

            if (gameObject is null)
            {
                return statusCache[key] = null;
            }

            if (gameObject is not BattleChara chara)
            {
                return statusCache[key] = null;
            }

            foreach (var status in chara.StatusList)
            {
                if (status.StatusId == statusId &&
                    (!sourceId.HasValue || status.SourceId== 0 || status.SourceId == InvalidObjectID || status.SourceId == sourceId))
                {
                    return statusCache[key] = status;
                }
            }

            return statusCache[key] = null;
        }

        private void OnFrameworkUpdate(Framework framework)
        {
            statusCache.Clear();
            cooldownCache.Clear();
        }

        public void Dispose()
        {
            DalamudService.Framework.Update -= OnFrameworkUpdate;
        }
    }
}