/*
 * Title:"Dungoen and dragons"
 *      
 *     Global layer: display small object when player getting close in range
 *      
 * Description:
 *     display small object when player getting close in range
 *     hide small object when player is too far away from object
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

using Kernal;

namespace Global {
    public class SmallObjLayerControl : MonoBehaviour
    {
        public int intDisappearDistance = 10;   //hide and show range
        private float[] distanceArray = new float[32];

        // Start is called before the first frame update
        void Start()
        {
            distanceArray[9] = intDisappearDistance;
            Camera.main.layerCullDistances = distanceArray;
        }


    }
}


