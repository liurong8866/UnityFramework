//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;

//namespace Framework.UI
//{
//    /// <summary>
//    /// 光标行为类
//    /// </summary>
//    public class UlCursor : MonoBehaviour
//    {
//        #region 公共变量

//        public string atlasPath;

//        public CursorInfo cursorInfo = new CursorInfo();

//        private IList<Texture2D> cursorTexture;

//        private CursorInfo lastStatus = CursorInfo.Default;
//        private CursorInfo currentStatus = CursorInfo.Default;

//        #endregion

//        #region 事件函数

//        void Start()
//        {
//            if (cursorInfo != null)
//            {
//                cursorInfo.AtlasPath = atlasPath;
//            }

//            if (atlasPath == "")
//            {
//                Debug.LogWarning("尚未指定光标Atlas贴图");
//            }

//            //设置默认状态
//            currentStatus = CursorInfo.Default;

//            //获取当前光标 
//            cursorTexture = cursorInfo[currentStatus];

//            //初始化CursorList 延迟一下加载,避免进入画面光标未变化。
//            Invoke("Initalize", 0.1f);
//        }

//        void Update()
//        {
//            //获取当前光标 
//            if (lastStatus.ToString() != currentStatus.ToString())
//            {
//                cursorTexture = cursorInfo[currentStatus];

//                StartCoroutine("SetCursor");

//                lastStatus = currentStatus;
//            }
//        }

//        void OnDisable()
//        {
//            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
//        }

//        #endregion

//        #region 方法函数

//        //初始化光标
//        private void Initalize()
//        {
//            StartCoroutine("SetCursor");

//        }

//        //设置光标
//        private IEnumerator SetCursor()
//        {
//            if (cursorTexture != null)
//            {
//                if (cursorTexture.Count == 1)
//                {
//                    Cursor.SetCursor(cursorTexture[0], cursorInfo.PointOffset, cursorInfo.Mode);
//                }
//                else if (cursorTexture.Count > 1)
//                {
//                    //此处避免用 foreach 有可能cursorTexture在执行遍历中 已经做过变更，这对 foreach是不允许的，也即foreach必须要遍历完成所有对象才肯罢休
//                    for (int i = 0; i < cursorTexture.Count; i++)
//                    {
//                        Cursor.SetCursor(cursorTexture[i], cursorInfo.PointOffset, cursorInfo.Mode);

//                        if (i == cursorTexture.Count - 1 && cursorInfo.Isloop(this.currentStatus))
//                        {
//                            i = 0;
//                        }

//                        yield return new WaitForSeconds(0.2f);
//                    }
//                }
//            }
//        }

//        #endregion

//        #region 方法属性

//        //光标类型
//        public CursorInfo CurrentStatus
//        {
//            get { return this.currentStatus; }

//            set { this.currentStatus = value; }
//        }

//        #endregion

//        static public UlCursor Lisener(GameObject go)
//        {
//            UlCursor listener = go.GetComponent<UlCursor>();

//            if (listener == null) listener = go.AddComponent<UlCursor>();

//            return listener;
//        }

//    }
//}