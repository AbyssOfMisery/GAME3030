/*
 * Title:"Dungoen and dragons"
 *      
 *      test layer: testing purchase shop 
 *      
 * Description:
 *         
 * Date:2020
 * 
 * Verstion: 0.1
 * 
 * Modify Recoder;
 *  
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;


namespace Test
{
    public class TestInventory : MonoBehaviour, IBeginDragHandler, IDragHandler,IEndDragHandler
    {
        private CanvasGroup canvasGroup;
        private Vector3 oldPosition;
        private RectTransform _MyRectTransform;

        /// <summary>
        /// before you drag item
        /// </summary>
        /// <param name="eventData"></param>
        public void OnBeginDrag(PointerEventData eventData)
        {
            canvasGroup.blocksRaycasts = false;
            this.gameObject.transform.SetAsLastSibling();

        }

        /// <summary>
        /// draging item
        /// </summary>
        /// <param name="eventData"></param>
        public void OnDrag(PointerEventData eventData)
        {
            Vector3 globalMousePosition;

            //get screen position turn into vector2
            if(RectTransformUtility.ScreenPointToWorldPointInRectangle(_MyRectTransform,eventData.position,eventData.pressEventCamera,out globalMousePosition))
            {
                _MyRectTransform.position = globalMousePosition;
            }

        }

        /// <summary>
        /// end of draging
        /// </summary>
        /// <param name="eventData"></param>
        public void OnEndDrag(PointerEventData eventData)
        {
            //current mouse position(check if its in those block)
            GameObject cur = eventData.pointerEnter;
            if(cur!=null)
            {
                if(cur.name.Equals("ImgGoal"))
                {
                    _MyRectTransform.position = cur.transform.position;
                    oldPosition = _MyRectTransform.position;
                }
                //didn't touching those blocks
                else
                {
                    _MyRectTransform.position = oldPosition;
                    //Prevent penetration, allow items to move
                    canvasGroup.blocksRaycasts = true;
                }
            }
            //drag items to empty block
            else
            {
                _MyRectTransform.position = oldPosition;
            }

        }

        // Start is called before the first frame update
        void Start()
        {
            //get this CanvasGroup 
            canvasGroup = this.GetComponent<CanvasGroup>();
            //get this RectTransform
            _MyRectTransform = this.transform as RectTransform;

            //get old position
            oldPosition = _MyRectTransform.position;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

