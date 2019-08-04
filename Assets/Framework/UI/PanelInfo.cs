﻿
using System.Collections.Generic;

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
        public PanelShowMode ShowModle { get; set; }

        //穿透类型
        public PanelLucenyType LucenyType { get; set; }

        //朋友，如果该窗口打开，则同时打开朋友窗口
        public List<PanelInfo> Friends { get; set; }

    }

    [System.Serializable]
    public class PanelInfoList
    {
        public System.Collections.Generic.List<PanelInfo> PanelList;
    }
}
