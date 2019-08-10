using UnityEngine;
using UnityEngine.EventSystems;

namespace Framework.UI
{
    public class DragablePanel : BasePanel, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private Camera uiCamera;

        //UI和指针的位置偏移量
        private Vector3 offset;

        private RectTransform rectTransform;

        float minWidth;             //水平最小拖拽范围
        float maxWidth;             //水平最大拖拽范围
        float minHeight;            //垂直最小拖拽范围  
        float maxHeight;            //垂直最大拖拽范围
        float rangeX;               //拖拽范围
        float rangeY;               //拖拽范围

        protected override void Awake()
        {
            base.Awake();

            uiCamera = GameObject.Find("UIRoot/UICamera").GetComponent<Camera>();

            rectTransform = transform.GetComponent<RectTransform>();

            //设置左上角为面板坐标原点
            rectTransform.pivot = new Vector2(0, 1);

            //设置左下角为Canvase坐标原点
            rectTransform.anchorMin = new Vector2(0, 0);
            rectTransform.anchorMax = new Vector2(0, 0);

            minWidth = -1 * rectTransform.rect.width / 2;
            maxWidth = Screen.width - (rectTransform.rect.width / 2);
            minHeight = rectTransform.rect.height / 2;
            maxHeight = Screen.height + (rectTransform.rect.height / 2);
        }
                
        void Update()
        {
           DragRangeLimit();
        }

        /// <summary>
        /// 拖拽范围限制
        /// </summary>
        void DragRangeLimit()
        {
            Debug.Log(rectTransform.anchoredPosition.x + "," + rectTransform.anchoredPosition.y);

            //限制水平/垂直拖拽范围在最小/最大值内
            rangeX = Mathf.Clamp(rectTransform.anchoredPosition.x, minWidth, maxWidth);
            rangeY = Mathf.Clamp(rectTransform.anchoredPosition.y, minHeight, maxHeight) ;

            //更新位置
            rectTransform.anchoredPosition = new Vector3(rangeX, rangeY, 0);
        }

        /// <summary>
        /// 开始拖拽
        /// </summary>
        public void OnBeginDrag(PointerEventData eventData)
        {
            Vector3 globalMousePos;

            //将屏幕坐标转换成世界坐标
            if (RectTransformUtility.ScreenPointToWorldPointInRectangle(rectTransform, eventData.position, uiCamera, out globalMousePos))
            {
                //计算UI和指针之间的位置偏移量
                offset = rectTransform.position - globalMousePos;
            }
        }

        /// <summary>
        /// 拖拽中
        /// </summary>
        public void OnDrag(PointerEventData eventData)
        {
            SetDraggedPosition(eventData);
        }

        /// <summary>
        /// 结束拖拽
        /// </summary>
        public void OnEndDrag(PointerEventData eventData)
        {

        }

        /// <summary>
        /// 更新UI的位置
        /// </summary>
        private void SetDraggedPosition(PointerEventData eventData)
        {
            Vector3 globalMousePos;

            if (RectTransformUtility.ScreenPointToWorldPointInRectangle(rectTransform, eventData.position, uiCamera, out globalMousePos))
            {
                rectTransform.position = offset + globalMousePos;
            }
        }
    }
}