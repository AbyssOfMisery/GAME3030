/*
 * Title:"Dungoen and dragons"
 *      
 *      Control layer: Make Object Rotate
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

namespace Control {
    public class MakeObjectRotate : BaseControl
    {
        public float floRotationSpeed = 1f;

        // Update is called once per frame
        void Update()
        {
            this.gameObject.transform.Rotate(Vector3.up, floRotationSpeed);
        }
    }

}

