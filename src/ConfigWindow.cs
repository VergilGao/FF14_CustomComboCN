/*
 * filename: PluginService.cs
 * maintainer: VergilGao
 * description:
 *  插件的设置界面
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Security.Cryptography;

using CustomComboPlugin.Attributes;
using CustomComboPlugin.Combos;

using Dalamud.Interface;
using Dalamud.Interface.Colors;
using Dalamud.Interface.Windowing;
using Dalamud.Logging;

using ImGuiNET;

namespace CustomComboPlugin
{
    internal class ConfigWindow : Window
    {
        private readonly Dictionary<byte, Dictionary<ushort, CustomComboInfoAttribute>> groupCombos;
        private readonly Dictionary<ushort, List<(byte JobId, ushort ComboId)>> conflictCombos;
        private readonly Dictionary<ushort, List<CustomComboInfoAttribute>> comboChildren;

        private readonly Vector4 shadedColor = new(0.68f, 0.68f, 0.68f, 1.0f);

        public ConfigWindow() : base("自定义连击设置")
        {
            RespectCloseHotkey = true;

            groupCombos = Assembly.GetAssembly(typeof(CustomCombo))!.GetTypes()
                                   .Where(t => !t.IsAbstract &&
                                               t.BaseType == typeof(CustomCombo) &&
                                               t.GetCustomAttribute<ObsoleteAttribute>() is null &&
                                               t.GetCustomAttribute<CustomComboInfoAttribute>() is not null)
                                   .Select(t => t.GetCustomAttribute<CustomComboInfoAttribute>())
                                   .Where(info => PluginConfiguration.GetParent(info.ComboId) == null) // 没有父节点的，有父节点的我们要在后面给子节点里创造
                                   .OrderBy(info => info.JobId)
                                   .ThenBy(info => info.Order)
                                   .GroupBy(info => info.JobId)
                                   .ToDictionary(g => g.Key, g => g.ToDictionary(c => c.ComboId));

            conflictCombos = Assembly.GetAssembly(typeof(CustomCombo))!.GetTypes()
                                     .Where(t => !t.IsAbstract &&
                                                 t.BaseType == typeof(CustomCombo) &&
                                                 t.GetCustomAttribute<ObsoleteAttribute>() is null &&
                                                 t.GetCustomAttribute<CustomComboInfoAttribute>() is not null &&
                                                 t.GetCustomAttributes<ConflictComboAttribute>().Count() > 0)
                                     .ToDictionary(
                                        t => t.GetCustomAttribute<CustomComboInfoAttribute>().ComboId,
                                        t =>
                                        {
                                            var jobId = t.GetCustomAttribute<CustomComboInfoAttribute>().JobId;
                                            return t.GetCustomAttributes<ConflictComboAttribute>().Select(c => (jobId, c.ConflictId)).ToList();
                                        });

            comboChildren = Assembly.GetAssembly(typeof(CustomCombo))!.GetTypes()
                                    .Where(t => !t.IsAbstract &&
                                                 t.BaseType == typeof(CustomCombo) &&
                                                 t.GetCustomAttribute<ObsoleteAttribute>() is null &&
                                                 t.GetCustomAttribute<CustomComboInfoAttribute>() is not null)
                                    .Select(t => t.GetCustomAttribute<CustomComboInfoAttribute>())
                                    .Where(info => PluginConfiguration.GetParent(info.ComboId) != null)
                                    .Select(info => (Parent: PluginConfiguration.GetParent(info.ComboId).Value, Child: info))
                                    .GroupBy(pair => pair.Parent)
                                    .ToDictionary(g => g.Key,
                                                  g => g.Select(pair => pair.Child)
                                                        .OrderBy(info => info.Order).ToList());

            SizeCondition = ImGuiCond.FirstUseEver;
            Size = new Vector2(740, 490);
        }

        public override void Draw()
        {
            ImGui.Text("在这里配置你需要的连击功能。");

            var showSecrets = PluginService.Configuration.EnableSecretCombos;

            if (ImGui.Checkbox("我的底线还能再低一点", ref showSecrets))
            {
                PluginService.Configuration.EnableSecretCombos = showSecrets;
                PluginService.Configuration.Save();
            }

            if (ImGui.IsItemHovered())
            {
                ImGui.BeginTooltip();
                ImGui.TextUnformatted("——底线——");
                ImGui.EndTooltip();
            }

            var hideChildren = PluginService.Configuration.HideChildren;
            if (ImGui.Checkbox("隐藏未启用的连击的子选项", ref hideChildren))
            {
                PluginService.Configuration.HideChildren = hideChildren;
                PluginService.Configuration.Save();
            }

            ImGui.BeginChild("scrolling", new Vector2(0, -1), true);

            ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, new Vector2(0, 5));

            var i = 1;

            foreach (var jobId in groupCombos.Keys)
            {
                if (Job.Names.TryGetValue(jobId, out var jobName))
                {
                    if (ImGui.CollapsingHeader(jobName))
                    {
                        foreach (var info in groupCombos[jobId].Values)
                        {
                            DrawPreset(info, ref i);
                        }
                    }
                    else
                    {
                        i += groupCombos[jobId].Count;
                    }
                }
                else
                {
                    PluginLog.Warning("未知的JobId:{@JobId}", jobId);
                }
            }

            ImGui.PopStyleVar();

            ImGui.EndChild();
        }

        private void DrawPreset(CustomComboInfoAttribute info, ref int i)
        {
            var comboId = info.ComboId;

            var enabled = PluginService.Configuration.IsEnabled(comboId);
            var secret = PluginService.Configuration.IsSecret(comboId);
            var conflicts = PluginService.Configuration.GetConflicts(comboId);
            var showSecrets = PluginService.Configuration.EnableSecretCombos;
            var parent = PluginConfiguration.GetParent(comboId);

            if (secret && !showSecrets)
            {
                return;
            }

            ImGui.PushItemWidth(200);

            if (ImGui.Checkbox(info.Name, ref enabled))
            {
                if (enabled)
                {
                    EnableParentCombo(comboId);
                    PluginService.Configuration.EnabledActions.Add(comboId);

                    if (conflicts != null)
                    {
                        foreach (var conflict in conflicts)
                        {
                            PluginService.Configuration.EnabledActions.Remove(conflict);
                        }
                    }
                }
                else
                {
                    PluginService.Configuration.EnabledActions.Remove(comboId);
                }

                PluginService.Configuration.Save();
            }

            if (secret)
            {
                ImGui.SameLine();
                ImGui.Text("  ");
                ImGui.SameLine();
                ImGui.PushFont(UiBuilder.IconFont);
                ImGui.PushStyleColor(ImGuiCol.Text, ImGuiColors.HealerGreen);
                ImGui.Text(FontAwesomeIcon.Star.ToIconString());
                ImGui.PopStyleColor();
                ImGui.PopFont();

                if (ImGui.IsItemHovered())
                {
                    ImGui.BeginTooltip();
                    ImGui.TextUnformatted("Secret");
                    ImGui.EndTooltip();
                }
            }

            ImGui.PopItemWidth();

            ImGui.PushStyleColor(ImGuiCol.Text, shadedColor);
            ImGui.TextWrapped($"#{info.ComboId:X4}: {info.Description}");
            ImGui.PopStyleColor();
            ImGui.Spacing();

            if (conflictCombos.TryGetValue(comboId, out var conflictInfos))
            {
                var conflictText = conflictInfos.Select(conflict =>
                {
                    if (groupCombos.TryGetValue(conflict.JobId, out var groupCombo))
                    {
                        if (groupCombo.TryGetValue(conflict.ComboId, out var conflictInfo))
                        {
                            if (!showSecrets && PluginService.Configuration.IsSecret(conflictInfo.ComboId))
                            {
                                return string.Empty;
                            }

                            return $"\n - {conflictInfo.Name}";
                        }
                        else
                        {
                            PluginLog.Warning("GroupCombos未收录ComboId={@ComboId}的CustomCombo!", conflict.ComboId);
                        }
                    }
                    else
                    {
                        PluginLog.Warning("GroupCombos未收录JobId={@JobId}的CustomCombo!", conflict.JobId);
                    }

                    return string.Empty;
                }).Aggregate((t1, t2) => $"{t1}{t2}");

                if (conflictText.Length > 0)
                {
                    ImGui.TextColored(shadedColor, $"与以下连击冲突： {conflictText}");
                    ImGui.Spacing();
                }
            }

            i++;

            var hideChildren = PluginService.Configuration.HideChildren;
            if (enabled || !hideChildren)
            {
                if (comboChildren.TryGetValue(comboId, out var children))
                {
                    if (children.Count > 0)
                    {
                        ImGui.Indent();

                        foreach (var childInfo in children)
                        {
                            DrawPreset(childInfo, ref i);
                        }

                        ImGui.Unindent();
                    }
                }
            }
        }

        private static void EnableParentCombo(ushort comboId)
        {
            var parentMaybe = PluginConfiguration.GetParent(comboId);
            while (parentMaybe != null)
            {
                var parent = parentMaybe.Value;

                if (!PluginService.Configuration.EnabledActions.Contains(parent))
                {
                    PluginService.Configuration.EnabledActions.Add(parent);

                    var conflicts = PluginService.Configuration.GetConflicts(parent);

                    if (conflicts != null)
                    {
                        foreach (var conflict in conflicts)
                        {
                            PluginService.Configuration.EnabledActions.Remove(conflict);
                        }
                    }
                }

                parentMaybe = PluginConfiguration.GetParent(parent);
            }
        }
    }
}