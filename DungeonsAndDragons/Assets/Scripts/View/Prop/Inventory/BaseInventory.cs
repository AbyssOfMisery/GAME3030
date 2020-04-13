/*
 * Title:"Dungoen and dragons"
 *      
 *      view layer: inventory system
 *      
 * Description:
 *         drag items into blocks
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

using Kernal;
using Global;

namespace View {
    public class BaseInventory : MonoBehaviour
    {

        protected string strMoveToTargetGridName;

        private CanvasGroup canvasGroup;
        private Vector3 oldPosition;
        private Transform _MyTransform;
        private RectTransform _MyRectTransform;

        /// <summary>
        /// get this class instance, and run by child class
        /// </summary>
        protected void RunInstanceByChildClass()
        {
            Base_Start();
        }

        /// <summary>
        /// before you drag item
        /// </summary>
        /// <param name="eventData"></param>
        public void Base_OnBeginDrag(PointerEventData eventData)
        {
            canvasGroup.blocksRaycasts = false;
            this.gameObject.transform.SetAsLastSibling();
            oldPosition = _MyTransform.position;
        }

        /// <summary>
        /// draging item
        /// </summary>
        /// <param name="eventData"></param>
        public void Base_OnDrag(PointerEventData eventData)
        {
            Vector3 globalMousePosition;

            //get screen position turn into vector2
            if (RectTransformUtility.ScreenPointToWorldPointInRectangle(_MyRectTransform, eventData.position, eventData.pressEventCamera, out globalMousePosition))
            {
                _MyRectTransform.position = globalMousePosition;
            }

        }

        /// <summary>
        /// end of draging
        /// </summary>
        /// <param name="eventData"></param>
        public void Base_OnEndDrag(PointerEventData eventData)
        {
            //current mouse position(check if its in those block)
            GameObject cur = eventData.pointerEnter;
            if (cur != null)
            {
                if (cur.name.Equals(strMoveToTargetGridName))
                {
                    _MyTransform.position = cur.transform.position;
                    oldPosition = _MyRectTransform.position;

                    //run item function
                    InvokeMethodByEndDrag();

                }
                //didn't touching those blocks
                else
                {
                    //will move item back to inventory valid position
                    if(cur.tag==eventData.pointerDrag.tag&& cur.name!=eventData.pointerDrag.name)
                    {
                        Vector3 targetPosition = cur.transform.position;
                        cur.transform.position = oldPosition;
                        _MyTransform.position = targetPosition;
                        oldPosition = _MyTransform.position;
                    }
                    else
                    {
                        _MyTransform.position = oldPosition;
                    }
                     //Prevent penetration, allow items to move
                     canvasGroup.blocksRaycasts = true;
                }
            }
            //drag items to empty block
            else
            {
                _MyTransform.position = oldPosition;
            }

        }

        // Start is called before the first frame update
        void Base_Start()
        {
            //get this CanvasGroup 
            canvasGroup = this.GetComponent<CanvasGroup>();
            //get this RectTransform
            _MyRectTransform = this.transform as RectTransform;
            //get item transform
            _MyTransform = this.transform;
            //get old position
            oldPosition = _MyRectTransform.position;
        }

        /// <summary>
        /// when item is equipped this img color will be faded
        /// </summary>
        protected virtual void InvokeMethodByEndDrag()
        {
            print(GetType()+ "/InvokeMethodByEndDrag()");
        }
    }
}

