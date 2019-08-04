
namespace Framework.UI
{
    /// <summary>
    /// 面板显示级别
    /// </summary>
    public enum PanelLevel
    {
        /// <summary>
        /// 背景层,菜单背景
        /// </summary>
        Background = 0,

        /// <summary>
        /// 默认层，通常放置此处即可
        /// </summary>
        Normal = 1,

        /// <summary>
        /// 持续存在层 如：图标
        /// </summary>
        Fixed = 2,

        /// <summary>
        /// 弹出层,物品栏弹窗等
        /// </summary>
        Popup = 3,

        /// <summary>
        /// 对话框层，人物对话弹窗等
        /// </summary>
        Toast = 4,

        /// <summary>
        /// 信息预览层，如：装备介绍
        /// </summary>
        Information = 5,

        /// <summary>
        /// 新手引导层
        /// </summary>
        Guide = 6,

        /// <summary>
        /// 最高层
        /// </summary>
        Forward = 7
    }

    /// <summary>
    /// 面板显示模式
    /// </summary>
    public enum PanelShowMode
    {
        /// <summary>
        /// 普通：可与多窗口并存
        /// </summary>
        Normal,

        /// <summary>
        /// 唯一：如果有其他同级别窗口，则隐藏其他窗口
        /// </summary>
        Alone,

        /// <summary>
        /// 非模态：同级窗口最高层显示，不关心其他窗口，点击遮罩层，消失
        /// </summary>
        Modeless,

        /// <summary>
        /// 模态：同级窗口最高层显示，不关心其他窗口，例如：购买时的 确认框，遮罩层不可点击
        /// </summary>
        Modal
    }
    
    /// <summary>
    /// 面板透明度类型
    /// </summary>
    public enum PanelLucenyType
    {
        /// <summary>
        /// 完全透明，不能穿透
        /// </summary>
        Lucency,

        /// <summary>
        /// 半透明，不能穿透
        /// </summary>
        Translucence,

        /// <summary>
        /// 低透明度，不能穿透
        /// </summary>
        ImPenetrable,

        /// <summary>
        /// 透明可以穿透
        /// </summary>
        Pentrate
    }
}
