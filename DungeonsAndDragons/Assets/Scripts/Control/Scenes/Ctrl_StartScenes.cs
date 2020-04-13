/*
 * Title:"Dungoen and dragons"
 *      
 *       Control Layer: start game and load game
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
using Kernal;

namespace Control
{
    public class Ctrl_StartScenes : BaseControl
    {
        public static Ctrl_StartScenes instance; // instance

        public AudioClip AudBackground; //backgroun audio
        private void Awake()
        {
            //Get this class instance
            instance = this;
        }

        private void Start()
        {
            //Setup audio volumns
            AudioManager.SetAudioBackgroundVolumns(0.5f);
           
            AudioManager.SetAudioEffectVolumns(1f);
            //play background music
            
            //AudioManager.PlayBackground("StartScenes");//quick but will need some ram 

            AudioManager.PlayBackground(AudBackground);//it doesnt need ram. its good for while music file is too big
        }

        //click to start new game
        internal void ClickNewGame()
        {
            //print(GetType()+ "/ClickNewGame()");

            //enter loading scenes
            StartCoroutine("EnterNextScenes");

        }

        //click to continue the game
        internal void ClickGameContinue()
        {
            print(GetType() + "/ClickGameContinue()");

            //load saved game 

            StartCoroutine("ContinueGame");
        }

        IEnumerator EnterNextScenes() // enter next scenes
        {
            //Scene fades out
            FadeInAndOut.Instance.SetScenesToBlack(); //fade out
            yield return new WaitForSeconds(3.0f);
            //load scenes
            base.EnterNextScenes(ScenesEnum.LogonScenes);
        }

        //load saved game 
        IEnumerator ContinueGame()
        {
            //load save game data
            SaveAndLoading.GetInstance().LoadingGame_GlobalParameter();

            //Scene fades out
            FadeInAndOut.Instance.SetScenesToBlack(); //fade out
            yield return new WaitForSeconds(3.0f);
            //load scenes
            base.EnterNextScenes(GlobalParaMgr.NextScenesName);

        }

    }
}


