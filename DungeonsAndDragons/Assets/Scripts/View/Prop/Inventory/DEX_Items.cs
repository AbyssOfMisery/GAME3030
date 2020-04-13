/*
 * Title:"Dungoen and dragons"
 *      
 *      view layer: inventory system
 *                  "Dexterity items"
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

using Model;
using Kernal;

namespace View
{
    public class DEX_Items : BaseInventory, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        //define "target inventory block " name
        public string StrTargetGridName = "Img_DEX";

        public float FloADDPlayerMaxDEX = 10.0f;

        public void OnBeginDrag(PointerEventData eventData)
        {
            base.Base_OnBeginDrag(eventData);
        }

        public void OnDrag(PointerEventData eventData)
        {
            base.Base_OnDrag(eventData);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            base.Base_OnEndDrag(eventData);
        }

        // Start is called before the first frame update
        void Start()
        {
            //assign vaule to target
            base.strMoveToTargetGridName = StrTargetGridName;
            base.RunInstanceByChildClass();
        }

        /// <summary>
        /// rewrite this function
        /// </summary>
        protected override void InvokeMethodByEndDrag()
        {
            print(GetType() + "/InvokeMethodByEndDrag()");
            PlayerSaveDataProxy.GetInstance().IncreaseMaxDEX(FloADDPlayerMaxDEX);
            PlayerSaveDataProxy.GetInstance().UpdateDEXValues();
        }
    }
}


