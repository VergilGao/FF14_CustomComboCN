﻿/*
 * filename: ComboManager.cs
 * maintainer: VergilGao
 * description:
 *  连击管理器
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using CustomComboPlugin.Attributes;
using CustomComboPlugin.Combos;

using Dalamud.Hooking;
using Dalamud.Logging;

namespace CustomComboPlugin
{
    internal sealed class ComboManager : IDisposable

    {
        private delegate ulong IsIconReplaceableDelegate(uint actionID);

        private delegate uint GetIconDelegate(IntPtr actionManager, uint actionID);

        private readonly List<CustomCombo> customCombos;
        private readonly Hook<IsIconReplaceableDelegate> isIconReplaceableHook;
        private readonly Hook<GetIconDelegate> getIconHook;

        private IntPtr actionManager = IntPtr.Zero;

        public ComboManager()
        {
            customCombos = Assembly.GetAssembly(typeof(CustomCombo))!.GetTypes()
                                   .Where(t => !t.IsAbstract &&
                                               t.BaseType == typeof(CustomCombo) &&
                                               t.GetCustomAttribute<ObsoluteComboAttribute>() is null &&
                                               t.GetCustomAttribute<CustomComboInfoAttribute>() is not null)
                                   .Select(t =>
                                   {
                                       var comboInfo = t.GetCustomAttribute<CustomComboInfoAttribute>();
                                       var combo = Activator.CreateInstance(t);
                                       t.BaseType.GetProperty(nameof(CustomCombo.JobId)).SetValue(combo, comboInfo.JobId);
                                       t.BaseType.GetProperty(nameof(CustomCombo.ComboId)).SetValue(combo, comboInfo.ComboId);

                                       return combo;
                                   })
                                   .Cast<CustomCombo>()
                                   .ToList();

            getIconHook = new Hook<GetIconDelegate>(PluginService.Address.GetAdjustedActionId, GetIconDetour);
            isIconReplaceableHook = new Hook<IsIconReplaceableDelegate>(PluginService.Address.IsActionIdReplaceable, IsIconReplaceableDetour);

            getIconHook.Enable();
            isIconReplaceableHook.Enable();
        }

        /// <summary>
        /// Calls the original hook.
        /// </summary>
        /// <param name="actionID">技能ID</param>
        /// <returns>The result from the hook.</returns>
        internal uint OriginalHook(uint actionID)
            => getIconHook.Original(actionManager, actionID);

        private unsafe uint GetIconDetour(IntPtr actionManager, uint actionId)
        {
            this.actionManager = actionManager;

            try
            {
                if (DalamudService.ClientState.LocalPlayer == null)
                {
                    return OriginalHook(actionId);
                }

                var lastComboMove = *(uint*)PluginService.Address.LastComboMove;
                var comboTime = *(float*)PluginService.Address.ComboTimer;
                var level = DalamudService.ClientState.LocalPlayer?.Level ?? 0;

                foreach (var combo in customCombos)
                {
                    if (combo.TryInvoke(actionId, level, lastComboMove, comboTime, out var newActionId))
                    {
                        return newActionId;
                    }
                }

                return OriginalHook(actionId);
            }
            catch (Exception ex)
            {
                PluginLog.Error(ex, "Don't crash the game");
                return OriginalHook(actionId);
            }
        }

        private ulong IsIconReplaceableDetour(uint actionId) => 1;

        public void Dispose()
        {
            getIconHook?.Dispose();
            isIconReplaceableHook?.Dispose();
        }
    }
}