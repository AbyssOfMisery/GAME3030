/*
 * Title:"Dungoen and dragons"
 *      
 *      view layer: Beginner's guide manager trigger
 *      
 * Description:
 *       
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

namespace View
{
    public interface IGuideTrigger
    {
        /// <summary>
        /// check trigger condition
        /// </summary>
        bool CheckCondition();

        /// <summary>
        /// run operation logic
        /// </summary>
        /// <returns></returns>
        bool RunOperation();
    }
}

