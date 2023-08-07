/*
 * filename: PluginConfiguration.cs
 * maintainer: VergilGao
 * description:
 *  插件配置
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using CustomComboPlugin.Attributes;
using CustomComboPlugin.Combos;

using Dalamud.Configuration;

using Newtonsoft.Json;

namespace CustomComboPlugin
{
    public sealed class PluginConfiguration : IPluginConfiguration
    {
        private static readonly HashSet<ushort> SecretCombos;
        private static readonly Dictionary<ushort, ushort[]> ConflictingCombos;
        private static readonly Dictionary<ushort, ushort?> ParentCombos; // parentCombos[ChildId] = ParentId

        static PluginConfiguration()
        {
            SecretCombos = Assembly.GetAssembly(typeof(CustomCombo))!.GetTypes()
                                   .Where(t => !t.IsAbstract &&
                                               t.BaseType == typeof(CustomCombo) &&
                                               t.GetCustomAttribute<ObsoluteComboAttribute>() is null &&
                                               t.GetCustomAttribute<CustomComboInfoAttribute>() is not null &&
                                               t.GetCustomAttribute<SecretComboAttribute>() is not null)
                                   .Select(t => t.GetCustomAttribute<CustomComboInfoAttribute>().ComboID)
                                   .ToHashSet();

            ConflictingCombos = Assembly.GetAssembly(typeof(CustomCombo))!.GetTypes()
                                        .Where(t => !t.IsAbstract &&
                                                    t.BaseType == typeof(CustomCombo) &&
                                                    t.GetCustomAttribute<ObsoleteAttribute>() is null &&
                                                    t.GetCustomAttribute<CustomComboInfoAttribute>() is not null &&
                                                    t.GetCustomAttributes<ConflictComboAttribute>().Count() > 0)
                                        .ToDictionary(
                                            t => t.GetCustomAttribute<CustomComboInfoAttribute>().ComboID,
                                            t => t.GetCustomAttributes<ConflictComboAttribute>().Select(attr => attr.ConflictID).ToArray());

            ParentCombos = Assembly.GetAssembly(typeof(CustomCombo))!.GetTypes()
                                        .Where(t => !t.IsAbstract &&
                                                    t.BaseType == typeof(CustomCombo) &&
                                                    t.GetCustomAttribute<ObsoleteAttribute>() is null &&
                                                    t.GetCustomAttribute<CustomComboInfoAttribute>() is not null)
                                        .ToDictionary(
                                            t => t.GetCustomAttribute<CustomComboInfoAttribute>().ComboID,
                                            t => t.GetCustomAttribute<ParentComboAttribute>()?.ParentID);
        }

        public int Version { get; set; } = 7;

        [JsonProperty("EnableSecretCombos")]
        public bool EnableSecretCombos { get; set; } = false;

        [JsonProperty("EnabledActionsV5")]
        public HashSet<ushort> EnabledActions { get; set; } = new();

        [JsonProperty("HideChildren")]
        public bool HideChildren { get; set; } = false;

        public bool IsEnabled(ushort comboId) => EnabledActions.Contains(comboId) && (EnableSecretCombos || !IsSecret(comboId));

        public bool IsSecret(ushort comboId) => SecretCombos.Contains(comboId);

        public ushort[]? GetConflicts(ushort comboId)
        {
            if (ConflictingCombos.TryGetValue(comboId, out var confilicts))
            {
                return confilicts;
            }
            else
            {
                return null;
            }
        }

        public static ushort? GetParent(ushort childId)
        {
            if (ParentCombos.TryGetValue(childId, out var parentId))
            {
                return parentId;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 保存设置
        /// </summary>
        public void Save() => DalamudService.Interface.SavePluginConfig(this);
    }
}