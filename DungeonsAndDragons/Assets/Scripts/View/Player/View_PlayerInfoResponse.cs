/*
 * Title:"Dungoen and dragons"
 *      
 *     View Mode: displayer character info
 *      
 * Description:
 *     displayer character infos; level, hp, mp, or etc 
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
    public class View_PlayerInfoResponse : MonoBehaviour
    {
        public GameObject goPlayerDetailInfoPanel;   //player info panel

        /// <summary>
        /// show or hide player info panel
        /// </summary>
        public void DisplayOrHidePlayerDetailInfoPanel()
        {
            goPlayerDetailInfoPanel.SetActive(!goPlayerDetailInfoPanel.activeSelf); 
        }
    }

}
