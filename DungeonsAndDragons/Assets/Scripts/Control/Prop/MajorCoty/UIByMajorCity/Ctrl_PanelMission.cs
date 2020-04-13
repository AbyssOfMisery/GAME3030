/*
 * Title:"Dungoen and dragons"
 *      
 *      Control layer: mission panel system
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

using Kernal;
using Global;

namespace Control
{
    
    public class Ctrl_PanelMission : BaseControl
    {
        public static Ctrl_PanelMission Instance; //instance

        private void Awake()
        {
            Instance = this;
        }

        /// <summary>
        /// enter level two 
        /// </summary>
        public void EnterLevelTwo()
        {
            base.EnterNextScenes(ScenesEnum.LevelTwo);
        }
    }

}
