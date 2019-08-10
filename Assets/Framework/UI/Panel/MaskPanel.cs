using UnityEngine;
using UnityEngine.UI;

namespace Framework.UI
{
    /// <summary>
    /// 遮罩层
    /// </summary>
    public class MaskPanel : MonoSingleton<MaskPanel>
    {
        private GameObject maskPanel;

        //单例模式
        protected MaskPanel() { }

        public void Init(Transform current, PanelLucenyType type)
        {
            maskPanel = GameObject.Find(UIConst.CON_PANELMASK);

            if (maskPanel.IsNull())
            {
                maskPanel = new GameObject(UIConst.CON_PANELMASK);
                maskPanel.AddComponent<RectTransform>();
                maskPanel.AddComponent<RawImage>();
            }

            RectTransform rect = maskPanel.GetComponent<RectTransform>();
            rect.localScale = Vector3.one;
            rect.localPosition = Vector3.zero;
            rect.anchorMax = Vector2.one;
            rect.anchorMin = Vector2.zero;
            rect.sizeDelta = Vector2.zero;

            maskPanel.transform.SetParent(current.parent);

            maskPanel.transform.SetAsFirstSibling();

            //设置遮罩透明度、穿透属性
            SetLucenyType(type);

        }

        /// <summary>
        /// 设置遮罩透明度、穿透属性
        /// </summary>
        private void SetLucenyType(PanelLucenyType type)
        {
            //启用遮罩窗体以及设置透明度
            float alpha = 0;
            switch (type)
            {
                //完全透明，不能穿透
                case PanelLucenyType.Lucency:
                    maskPanel.gameObject.SetActive(true);
                    alpha = UIConst.CON_PANELMASK_LUCENCY;
                    break;

                //半透明，不能穿透
                case PanelLucenyType.Translucence:
                    maskPanel.gameObject.SetActive(true);
                    alpha = UIConst.CON_PANELMASK_TRANSLUCENCE;
                    break;

                //低透明度，不能穿透
                case PanelLucenyType.ImPenetrable:
                    maskPanel.gameObject.SetActive(true);
                    alpha = UIConst.CON_PANELMASK_IMPENETRABLE;
                    break;

                //透明可以穿透
                case PanelLucenyType.Pentrate:
                    if (maskPanel.gameObject.activeInHierarchy)
                    {
                        maskPanel.gameObject.SetActive(false);
                    }
                    break;
            }

            maskPanel.GetComponent<RawImage>().color = new Color(1, 1, 1, alpha);
        }
    }
}
