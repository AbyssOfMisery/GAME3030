/*
 * Title:"Dungoen and dragons"
 *      
 *     Control layer : save and load game datas
 *      
 * Description:
 *    do response to click event
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
using Model;
using Global;

namespace Control
{
    public class Ctrl_PlayerUIResponse : BaseControl
    {
        public static Ctrl_PlayerUIResponse Instance;

        private void Awake()
        {
            Instance = this;
        }

        /// <summary>
        /// exit game
        /// </summary>
        public void ExitGame()
        {
            StartCoroutine("HandleSaveingGame");
        }

        IEnumerator HandleSaveingGame()
        {
            //save game
            SaveAndLoading.GetInstance().SaveGameProcess();
            
            //wait for 0.5 second until game is saved
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT5);
        }

    }


}
