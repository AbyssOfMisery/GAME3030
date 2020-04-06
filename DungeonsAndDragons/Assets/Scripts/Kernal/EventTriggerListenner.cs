/*
 * Title:"Dungoen and dragons"
 *      
 *      kernal layer: event trigger lisstener
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

namespace Kernal
{
    public class EventTriggerListenner : EventTrigger
    {
        public delegate void VoidDelegate(GameObject go);

        public VoidDelegate onClick;
        public VoidDelegate onDown;
        public VoidDelegate onEnter;
        public VoidDelegate onExit;
        public VoidDelegate onUp;
        public VoidDelegate onSelect;
        public VoidDelegate onUpdateSelect;
        
        /// <summary>
        /// get this event trigger listener component
        /// </summary>
        /// <param name="go">target gameobject</param>
        /// <returns></returns>
        public static EventTriggerListenner Get(GameObject go)
        {
            EventTriggerListenner listenner = go.GetComponent<EventTriggerListenner>();
            if(listenner == null)
            {
                listenner = go.AddComponent<EventTriggerListenner>();
           
            }

            return listenner;
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            if(onClick != null)
            {
                onClick(gameObject);
            }
        }

        public override void  OnPointerDown(PointerEventData eventData)
        {
            if (onDown != null)
            {
                onDown(gameObject);
            }
        }

        public override void OnPointerEnter(PointerEventData eventData)
        {
            if (onEnter != null)
            {
                onEnter(gameObject);
            }
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            if (onExit != null)
            {
                onExit(gameObject);
            }
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            if (onUp != null)
            {
                onUp(gameObject);
            }
        }

        public override void OnSelect(BaseEventData eventData)
        {
            if (onSelect != null)
            {
                onSelect(gameObject);
            }
        }

        public override void OnUpdateSelected(BaseEventData eventData)
        {
            if (onUpdateSelect != null)
            {
                onUpdateSelect(gameObject);
            }
        }


    }
}

