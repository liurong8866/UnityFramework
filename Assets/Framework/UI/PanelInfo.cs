
namespace Framework.UI
{
    [System.Serializable]
    public class PanelInfo
    {        
        //名称
        public string Name { get; set; }

        //路径
        public string Path { get; set; }

        //面板视图层级
        public PanelLevel Level { get; set; }

        //显示模式
        public PanelShowModle ShowModle { get; set; }

        //穿透类型
        public PanelLucenyType lucenyType { get; set; }

    }

    [System.Serializable]
    public class PanelInfoList
    {
        public System.Collections.Generic.List<PanelInfo> PanelList;
    }
}
