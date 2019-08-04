using System.Collections.Generic;
using UnityEngine;

namespace Framework.UI
{
    public class UIManager : Singleton<UIManager>
    {
        #region 变量定义

        private GameObject uiRoot;

        //UIPanel 路径字典
        private Dictionary<string, PanelInfo> panelInfoDic;
        
        //实例化场景中的UIPanel字典
        private Dictionary<string, BasePanel> panelInstanceDic;

        #endregion

        #region 构造函数

        private UIManager()
        {
            //字典初始化
            panelInfoDic = new Dictionary<string, PanelInfo>();
            panelInstanceDic = new Dictionary<string, BasePanel>();

            //初始化UIRoot，将他放置到场景中
            InitUIRoot();

            //初始化Panel信息列表
            InitPanelList();
        }
        #endregion

        #region 方法函数

        /// <summary>
        /// 实例化Panel到场景
        /// </summary>
        public BasePanel ShowPanel(string panelName)
        {
            //如果已实例化，返回实例
            BasePanel basePanel = panelInstanceDic.Value<string, BasePanel>(panelName);
            if (basePanel != null) return basePanel;

            //如果没有找到，则说明还未加载过
            PanelInfo panelInfo = panelInfoDic.Value<string, PanelInfo>(panelName);

            if (panelInfo.IsNotNullOrEmpty())
            {
                GameObject go = GameObject.Instantiate(Resources.Load(panelInfo.Path)) as GameObject;

                //找到面板所在层级对象
                Transform parent = uiRoot.transform.Find(panelInfo.Level.ToString());

                go.name = panelInfo.Name;
                go.transform.SetParent(parent, false);
                go.transform.localPosition = Vector3.zero;
                go.transform.localRotation = Quaternion.identity;
                go.transform.localScale = Vector3.one;

                basePanel = go.GetComponent<BasePanel>();

                //缓存面板实例
                panelInstanceDic[panelName] = basePanel;
            }

            return basePanel;
        }

        #endregion

        #region 初始化数据

        /// <summary>
        /// 初始化UIRoot
        /// </summary>
        private void InitUIRoot()
        {
            uiRoot = GameObject.Instantiate(Resources.Load(UIConst.CON_PATH_RESOURCE + UIConst.CON_UIROOT)) as GameObject;

            uiRoot.name = UIConst.CON_UIROOT;
            uiRoot.transform.localPosition = Vector3.zero;
            uiRoot.transform.localRotation = Quaternion.identity;
            uiRoot.transform.localScale = Vector3.one;

            //切换场景不被回收
            uiRoot.DontDestroyOnLoad();
        }

        /// <summary>
        /// 初始化Panel信息列表
        /// </summary>
        private void InitPanelList()
        {
            TextAsset textAsset = Resources.Load<TextAsset>(UIConst.CON_PATH_RESOURCE + UIConst.CON_PANELLIST);

            List<PanelInfo> panelInfoList = JsonFactory.Json().Deserialize<PanelInfoList>(textAsset.text)?.PanelList;

            panelInfoList?.ForEach(panelInfo => {panelInfoDic.Add(panelInfo.Name, panelInfo);});
        }

        #endregion

    }
}
