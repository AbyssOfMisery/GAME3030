/*
 * Title:"Dungoen and dragons"
 *      
 *       View Layer: Start Scenes
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
using Control;

namespace View
{
    public class View_StartScenes : MonoBehaviour
    {
        //New Game
        public void ClickNewGame()
        {
           // print(GetType()+"New Game");

            //call control script to load new game
            Ctrl_StartScenes.instance.ClickNewGame();   
        }

        //Continue game
        public void ClickGameContinue()
        {
            //print(GetType() + "Continue Game");

            //call control script to continue game
            Ctrl_StartScenes.instance.ClickGameContinue();

        }
    }
}

