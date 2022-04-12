/*
 * filename: DalamudService.cs
 * maintainer: VergilGao
 * description:
 *  插件用到的卫月服务
 */

using Dalamud.Data;
using Dalamud.Game;
using Dalamud.Game.ClientState;
using Dalamud.Game.ClientState.Buddy;
using Dalamud.Game.ClientState.JobGauge;
using Dalamud.Game.ClientState.Objects;
using Dalamud.Game.Command;
using Dalamud.IoC;
using Dalamud.Plugin;

namespace CustomComboPlugin
{
    /// <summary>
    /// 卫月框架提供的服务
    /// </summary>
    internal sealed class DalamudService
    {
        /// <summary>
        /// 卫月界面
        /// </summary>
        [PluginService]
        public static DalamudPluginInterface Interface { get; private set; } = null!;

        /// <summary>
        /// FF14客户端中的当前状态参数
        /// </summary>
        [PluginService]
        public static ClientState ClientState { get; private set; } = null!;

        /// <summary>
        /// 命令管理器
        /// </summary>
        [PluginService]
        public static CommandManager CommandManager { get; private set; } = null!;

        /// <summary>
        /// Dalamud 内部数据
        /// </summary>
        [PluginService]
        public static DataManager DataManager { get; private set; } = null!;

        /// <summary>
        /// FF14客户端的 Framework
        /// </summary>
        [PluginService]
        public static Framework Framework { get; private set; } = null!;

        /// <summary>
        /// 职业资源量表
        /// </summary>
        [PluginService]
        public static JobGauges JobGauges { get; private set; } = null!;

        /// <summary>
        /// 小队列表
        /// </summary>
        [PluginService]
        public static BuddyList BuddyList { get; private set; } = null!;

        /// <summary>
        /// 目标管理器
        /// </summary>
        [PluginService]
        public static TargetManager TargetManager { get; private set; } = null!;
    }
}