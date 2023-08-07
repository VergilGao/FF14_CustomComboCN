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
            ComboTimer = scanner.GetStaticAddressFromSig("F3 0F 11 05 ?? ?? ?? ?? F3 0F 10 45 ?? E8");

            GetAdjustedActionId = scanner.ScanText("E8 ?? ?? ?? ?? 8B F8 3B DF");

            IsActionIdReplaceable = scanner.ScanText("E8 ?? ?? ?? ?? 84 C0 74 4C 8B D3");

            PluginLog.Verbose("===== CustomCombo 寻址完成 =====");
            PluginLog.Verbose($"{nameof(GetAdjustedActionId)}   0x{GetAdjustedActionId:X}");
            PluginLog.Verbose($"{nameof(IsActionIdReplaceable)} 0x{IsActionIdReplaceable:X}");
            PluginLog.Verbose($"{nameof(ComboTimer)}            0x{ComboTimer:X}");
            PluginLog.Verbose($"{nameof(LastComboMove)}         0x{LastComboMove:X}");
        }
    }
}