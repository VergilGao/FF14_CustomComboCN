/*
 * filename: PluginService.cs
 * maintainer: VergilGao
 * description:
 *  插件的全局服务
 */

namespace CustomComboPlugin
{
    internal sealed class PluginService
    {
        /// <summary>
        /// 寻址
        /// </summary>
        public static PluginAddressResolver Address { get; set; } = null;

        /// <summary>
        /// 连击缓存
        /// </summary>
        public static CustomComboCache ComboCache { get; set; } = null;

        public static ComboManager ComboManager { get; set; } = null;

        /// <summary>
        /// 插件配置信息
        /// </summary>
        public static PluginConfiguration Configuration { get; set; } = null;
    }
}