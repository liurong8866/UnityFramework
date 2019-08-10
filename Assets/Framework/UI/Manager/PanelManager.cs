using System.Collections.Generic;
using UnityEngine;

namespace Framework.UI
{
    public class PanelManager : Singleton<PanelManager>
    {
        #region 变量定义

        private GameObject uiRoot;

        //UIPanel 路径字典
        private Dictionary<string, PanelInfo> panelInfoDic;
        
        //实例化场景中的UIPanel字典
        private Dictionary<string, BasePanel> panelInstanceDic;

        //保存场景中的UIPanel 入栈
        private Stack<BasePanel> panelStack;

        #endregion

        #region 构造函数

        private PanelManager()
        {
            //字典初始化
            panelInfoDic = new Dictionary<string, PanelInfo>();
            panelInstanceDic = new Dictionary<string, BasePanel>();
            panelStack = new Stack<BasePanel>();

            //初始化UIRoot，将他放置到场景中
            InitUIRoot();

            //初始化Panel信息列表
            InitPanelList();
        }

        #endregion

        #region 方法函数

        /// <summary>
        /// 显示面板,同时放入栈内
        /// </summary>
        public void OpenPanel(string panelName)
        {
            //实例化面板
            BasePanel panel = InstancePanel(panelName);
            
            panel.Enter();

            //switch(panel.PanelInfo.ShowModle)
            //{

            //    //普通：可与多窗口并存
            //    case PanelShowMode.Normal:

            //        ////栈首界面暂停
            //        //if (panelStack.Count > 0)
            //        //{
            //        //    panelStack.Peek().Pause();
            //        //}

            //        ////放入栈
            //        //panelStack.Push(panel);

            //        break;

            //    //唯一：如果有其他同级别窗口，则隐藏其他窗口
            //    case PanelShowMode.Alone:
                    
            //        break;

            //    //非模态：同级窗口最高层显示，不关心其他窗口，点击遮罩层，消失
            //    case PanelShowMode.Modeless:
            //        //MaskPanel.Instance.Init(panel.transform, PanelLucenyType.Lucency);
            //        break;

            //    //模态：同级窗口最高层显示，不关心其他窗口，例如：购买时的 确认框，遮罩层不可点击
            //    case PanelShowMode.Modal:
            //        break;
            //}
        }

        /// <summary>
        /// 隐藏面板
        /// </summary>
        public void ClosePanel()
        {
            if (panelStack.Count > 0)
            {
                //从栈中取出，并执行Exit方法
                panelStack.Pop().Exit();
            }

            if (panelStack.Count > 0)
            {
                //从栈中获取（不是取出）新界面，并激活
                panelStack.Peek().Resume();
            }
        }

        #endregion

        #region 初始化数据

        /// <summary>
        /// 初始化UIRoot
        /// </summary>
        private void InitUIRoot()
        {
            uiRoot = GameObject.Instantiate(Resources.Load(UIConst.CON_UIRESOURCE + UIConst.CON_UIROOT)) as GameObject;

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
            TextAsset textAsset = Resources.Load<TextAsset>(UIConst.CON_UIRESOURCE + UIConst.CON_PANELLIST);

            List<PanelInfo> panelInfoList = JsonFactory.Json().Deserialize<PanelInfoList>(textAsset.text)?.PanelList;

            panelInfoList?.ForEach(panelInfo => {panelInfoDic.Add(panelInfo.Name, panelInfo);});
        }
        
        /// <summary>
        /// 实例化Panel到场景
        /// </summary>
        private BasePanel InstancePanel(string panelName)
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

                //从配置中获取
                //go.transform.localPosition = Vector3.zero;
                //go.transform.localRotation = Quaternion.identity;
                //go.transform.localScale = Vector3.one;

                basePanel = go.GetComponent<BasePanel>();

                //赋值面板基础信息
                basePanel.PanelInfo = panelInfo;

                //缓存面板实例
                panelInstanceDic[panelName] = basePanel;
            }

            return basePanel;
        }

        #endregion

    }
}
