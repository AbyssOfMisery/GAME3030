/*
 * Title:"Dungoen and dragons"
 *      
 *      View layer: mission panel in major city
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
using Global;
using Control;

namespace View
{
    public class View_PanelMission : MonoBehaviour
    {

        /// <summary>
        /// enter next level (mission 1)
        /// </summary>
       public void EnterNextLevelTwo()
        {
            Ctrl_PanelMission.Instance.EnterLevelTwo();
        }
    }
}

