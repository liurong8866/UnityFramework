﻿using UnityEngine;
using UnityEngine.EventSystems;

namespace Framework.UI
{
    public class DragablePanel : BasePanel, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        //UI和指针的位置偏移量
        Vector3 offset;

        RectTransform rectTransform;

        float minWidth;             //水平最小拖拽范围
        float maxWidth;             //水平最大拖拽范围
        float minHeight;            //垂直最小拖拽范围  
        float maxHeight;            //垂直最大拖拽范围
        float rangeX;               //拖拽范围
        float rangeY;               //拖拽范围


        void Update()
        {
            DragRangeLimit();
        }

        protected override void Start()
        {
            rectTransform = transform.GetComponent<RectTransform>();

            minWidth = rectTransform.rect.width / 2;
            maxWidth = Screen.width - (rectTransform.rect.width / 2);
            minHeight = rectTransform.rect.height / 2;
            maxHeight = Screen.height - (rectTransform.rect.height / 2);
        }

        /// <summary>
        /// 拖拽范围限制
        /// </summary>
        void DragRangeLimit()
        {
            //限制水平/垂直拖拽范围在最小/最大值内
            rangeX = Mathf.Clamp(rectTransform.position.x, minWidth, maxWidth);
            rangeY = Mathf.Clamp(rectTransform.position.y, minHeight, maxHeight);

            //更新位置
            rectTransform.position = new Vector3(rangeX, rangeY, 0);
        }

        /// <summary>
        /// 开始拖拽
        /// </summary>
        public void OnBeginDrag(PointerEventData eventData)
        {
            Vector3 globalMousePos;

            //将屏幕坐标转换成世界坐标
            if (RectTransformUtility.ScreenPointToWorldPointInRectangle(rectTransform, eventData.position, null, out globalMousePos))
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

            if (RectTransformUtility.ScreenPointToWorldPointInRectangle(rectTransform, eventData.position, null, out globalMousePos))
            {
                rectTransform.position = offset + globalMousePos;
            }
        }
    }
}