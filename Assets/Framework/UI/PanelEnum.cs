
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
        BackgroundPanel = 0,

        /// <summary>
        /// 默认层，通常放置此处即可
        /// </summary>
        DefaultPanel = 1,

        /// <summary>
        /// 持续存在层 如：图标
        /// </summary>
        FixedPanel = 2,

        /// <summary>
        /// 弹出层,物品栏弹窗等
        /// </summary>
        PopupPanel = 3,

        /// <summary>
        /// 对话框层，人物对话弹窗等
        /// </summary>
        ToastPanel = 4,

        /// <summary>
        /// 信息预览层，如：装备介绍
        /// </summary>
        InfoPanel = 5,

        /// <summary>
        /// 新手引导层
        /// </summary>
        GuidePanel = 6,

        /// <summary>
        /// 最高层
        /// </summary>
        ForwardPanel = 7
    }

    /// <summary>
    /// 面板显示模式
    /// </summary>
    public enum PanelShowModle
    {
        /// <summary>
        /// 普通, 同一层级叠加
        /// </summary>
        Normal,

        /// <summary>
        /// 切换, 按照相反方向切换过去 原路弹回来
        /// </summary>
        Switch,

        /// <summary>
        /// 隐藏，覆盖掉其他窗口
        /// </summary>
        HideOther
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
