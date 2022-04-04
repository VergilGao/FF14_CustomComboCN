/*
 * filename: PluginAddressResolver.cs
 * maintainer: VergilGao
 * description:
 *  提供了插件需要调用的游戏功能寻址
 */

using System;

using Dalamud.Game;
using Dalamud.Logging;

namespace CustomComboPlugin
{
    /// <summary>
    /// 插件需要调用的游戏功能寻址
    /// </summary>
    internal class PluginAddressResolver : BaseAddressResolver
    {
        /// <summary>
        /// 连击计时器的地址
        /// </summary>
        public IntPtr ComboTimer { get; private set; }

        public IntPtr LastComboMove => ComboTimer + 0x04;

        /// <summary>
        /// Client::Game::ActionManager.GetAdjustedActionId
        /// </summary>
        public IntPtr GetAdjustedActionId { get; private set; }

        public IntPtr IsActionIdReplaceable { get; private set; }

        protected override void Setup64Bit(SigScanner scanner)
        {
            ComboTimer = scanner.GetStaticAddressFromSig("48 89 2D ?? ?? ?? ?? 85 C0 74 0F");

            GetAdjustedActionId = scanner.ScanText("E8 ?? ?? ?? ?? 8B F8 3B DF");

            IsActionIdReplaceable = scanner.ScanText("81 F9 ?? ?? ?? ?? 7F 35");

            PluginLog.Verbose("===== CustomCombo 寻址完成 =====");
            PluginLog.Verbose($"{nameof(GetAdjustedActionId)}   0x{GetAdjustedActionId:X}");
            PluginLog.Verbose($"{nameof(IsActionIdReplaceable)} 0x{IsActionIdReplaceable:X}");
            PluginLog.Verbose($"{nameof(ComboTimer)}            0x{ComboTimer:X}");
            PluginLog.Verbose($"{nameof(LastComboMove)}         0x{LastComboMove:X}");
        }
    }
}