/*
 * filename: StartUp.cs
 * maintainer: VergilGao
 * description:
 *  插件的启动页，初始化所有服务，注入必要信息
 */

using Dalamud.Game.Command;
using Dalamud.Interface.Windowing;
using Dalamud.Plugin;

namespace CustomComboPlugin
{
    internal sealed class StartUp : IDalamudPlugin
    {
        private const string Command = "/ccombo";

        private readonly WindowSystem windowSystem;
        private readonly ConfigWindow configWindow;

        public StartUp(DalamudPluginInterface pluginInterface)
        {
            pluginInterface.Create<DalamudService>();

            PluginService.Configuration = pluginInterface.GetPluginConfig() as PluginConfiguration ?? new PluginConfiguration();
            PluginService.Address = new PluginAddressResolver();
            PluginService.Address.Setup();

            PluginService.ComboCache = new CustomComboCache();
            PluginService.ComboManager = new ComboManager();

            configWindow = new();
            windowSystem = new(Name);
            windowSystem.AddWindow(configWindow);

            DalamudService.Interface.UiBuilder.OpenConfigUi += OnOpenConfigUi;
            DalamudService.Interface.UiBuilder.Draw += windowSystem.Draw;
            DalamudService.CommandManager.AddHandler(Command, new CommandInfo(OnCommand)
            {
                HelpMessage = "打开自定义连击的设置窗口。",
                ShowInHelp = true
            });
        }

        public string Name => "Custom Combo";

        private void OnOpenConfigUi() => configWindow.IsOpen = true;

        private void OnCommand(string command, string args)
        {
            configWindow.Toggle();
        }

        public void Dispose()
        {
            DalamudService.CommandManager.RemoveHandler(Command);

            DalamudService.Interface.UiBuilder.OpenConfigUi -= OnOpenConfigUi;
            DalamudService.Interface.UiBuilder.Draw -= windowSystem.Draw;

            PluginService.ComboCache?.Dispose();
            PluginService.ComboManager?.Dispose();
        }
    }
}