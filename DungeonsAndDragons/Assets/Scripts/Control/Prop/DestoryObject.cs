/*
 * Title:"Dungoen and dragons"
 *      
 *      Control layer: DestoryObject
 *      
 * Description:
 *           Enemy Animation
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

namespace Control
{
    public class DestoryObject : BaseControl
    {
        public float floDestoryTime = 2f;
      
        void Start()
        {
            Destroy(this.gameObject, floDestoryTime);
        }


    }

}
