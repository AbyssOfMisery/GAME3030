/*
 * Title:"Dungoen and dragons"
 *      
 *      Layer Control: Start Scenes
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
using UnityEngine.SceneManagement;
using Global;

namespace Control
{
    public class Ctrl_StartScenes : MonoBehaviour
    {
        public static Ctrl_StartScenes instance; // instance

        private void Awake()
        {
            //Get this class instance
            instance = this;
        }

        //click to start new game
        internal void ClickNewGame()
        {
            print(GetType()+ "/ClickNewGame()");

            //Scene fades out

            FadeInAndOut.Instance.SetScenesToBlack(); //fade out
        
            //load scenes
            SceneManager.LoadScene("LoadingScenes");
            

        }

        //click to continue the game
        internal void ClickGameContinue()
        {
            print(GetType() + "/ClickGameContinue()");
        }
    }
}


