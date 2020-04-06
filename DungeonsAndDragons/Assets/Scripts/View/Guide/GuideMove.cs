/*
 * Title:"Dungoen and dragons"
 *      
 *      view layer: beginner animation guide
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
using Kernal;

namespace View
{
    public class GuideMove : MonoBehaviour
    {
        public GameObject goMovingGoal;
        void Start()
        {
            iTween.MoveFrom(this.gameObject, 
                iTween.Hash("position",goMovingGoal.transform.position,
                "time", 1F,
                "looptype",iTween.LoopType.loop
                )
                );
        }

    }
}

