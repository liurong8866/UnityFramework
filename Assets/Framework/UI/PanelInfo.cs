
namespace Framework.UI
{
    [System.Serializable]
    public class PanelInfo
    {
        
        //名称
        public string Name;

        //路径
        public string Path;

        //面板视图层级
        public string Level;

        //public PanelLevel Level;

        //显示模式
        public string showModle;
        //public PanelShowModle ShowModle;

        //穿透类型
        public string lucenyType;
        //public PanelLucenyType LucenyType;
    }

    [System.Serializable]
    public class PanelInfoList
    {
        public System.Collections.Generic.List<PanelInfo> PanelList;
    }
}
