/*
 * Title:"Dungoen and dragons"
 *      
 *     Control layer : Major city scene manager
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
using Global;

namespace Control
{
    public class Ctrl_MajorCityScenes : BaseControl
    {
        public AudioClip AcBackground;      //major ciry background music

        IEnumerable Start()
        {
            if(AcBackground!=null)
            {
                AudioManager.PlayBackground(AcBackground);
            }
            //load player saved data

            if(GlobalParaMgr.CurGameType == CurrentGameType.Continue)
            {
                //load game 
                yield return new WaitForSeconds(2);
                SaveAndLoading.GetInstance().loadingGame_PlayerData();
            }
        }

    }
}

